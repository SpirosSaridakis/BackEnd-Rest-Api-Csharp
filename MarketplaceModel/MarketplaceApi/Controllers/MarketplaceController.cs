using MarketplaceModel.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
using MarketplaceApi.Models;
using MarketplaceApi.Services.Items;
using ErrorOr;


namespace MarketplaceApi.Controllers;


    
    public class MarketplaceController : ApiController
    {
        //this interface will be used for dependency injection
        private readonly IitemService _itemService;

        public MarketplaceController(IitemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost()]
        public IActionResult CreateItem(CreateItemRequest request)
        {
            //Creating the Item object by getting the properties of the sent request that the controller recieves
            //Using the Create function to verify that the contents of the request are valid
            ErrorOr<Item> CreationResult = Item.Create(request.name,request.discription,request.price,request.dayAdded);

            //If the result is an error we send things over to the ErrorController
            if(CreationResult.IsError){
                return Problem(CreationResult.Errors);
            }

            //If not then CreationResult holds an item as its value 
            Item item = CreationResult.Value;

            //Using the CreateItem method from our interface by passing it the item we just created
            //Also using an error or object to store the result given by the CreateItem method
            ErrorOr<Created> createItemResult = _itemService.CreateItem(item);
            
            //If the CreateItem returns an error we will use it to inform the client we got an error by using the Problem method of the ApiController
            if(createItemResult.IsError){
                return Problem(createItemResult.Errors);
            }
            // Here im using the CreatedAtAction method
            //the first parameter is the action in which the client can get the resource 
            return CreatedAtAction(nameof(CreateItem),new{id = item.Id},value:MapItemResponse(item));
        }

        //When this endpoint is called we create an instance of the class in which we have the methods for our "database"
        //Then, when we get the item with the given id we create a response and feed it back to the client
        [HttpGet("{id:guid}")]
        public IActionResult GetItem(Guid id)
        {
            ErrorOr<Item> getItemResult = _itemService.GetItem(id);
            
            //The getItemResult returns either a list of errors or an item, so the match method calls a function we specify for eithe return type
            //In case an error occures, we call our internal Problem method, which we get from the ApiController
            return getItemResult.Match(item => Ok(MapItemResponse(item)),errors =>Problem(errors));
            
        }

        //Here we create an item and again using the interface send the item to the "database"
        [HttpPut("{id:guid}")]
        public IActionResult UpdateItem(Guid id, UpdateItem request)
        {
            //Since we create an item in this function we also call the create function here and follow the same tactic 
            ErrorOr<Item> CreationResult = Item.Create(request.name,request.discription,request.price,request.dayAdded);

            if(CreationResult.IsError){
                return Problem(CreationResult.Errors);
            }

            Item item = CreationResult.Value;    

            ErrorOr<Updated> updateResult = _itemService.UpdateItem(item);
            return updateResult.Match(updated => Ok(), errors => Problem(errors));
        }

        //Here we will search for the item in question and if it exists delete it
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteItem(Guid id)
        {
            ErrorOr<Deleted> deleteResult = _itemService.DeleteItem(id);
            //Doing the same as in GetItem
            return deleteResult.Match(deleted => NoContent(), errors => Problem(errors));
        }

        public static CreateItemResponse MapItemResponse(Item item){
            
            return new CreateItemResponse(item.Id,item.Name,item.Discription,item.Price,item.DayAdded);

        }
    }
