using MarketplaceModel.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
using MarketplaceApi.Models;
using MarketplaceApi.Services.Items;
using ErrorOr;
using MarketplaceApi.ServiceErrors;

namespace MarketplaceApi.Controllers;


[ApiController]
    [Route("/CreateItem")]//This makes it so that every request needs to start with /CreateItem and then the methods just expand the route
    public class MarketplaceController : ControllerBase
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
            //Mapping the data that we get in the request to c#, which we use for our application
            Item item = new Item(Guid.NewGuid(),request.name,request.discription,request.price,request.dayAdded);

            //Using the CreateItem method from our interface by passing it the item we just created
            _itemService.CreateItem(item);


            //Creating a CreateItemResponse object to return to the client, it will contain the attributes of the object we created
            //Here im using the getters i have created in the Item Class to get the info i need
            //Getting the data and converting it to the API definition
            CreateItemResponse response = new CreateItemResponse(item.Id,item.Name,item.Discription,item.Price,item.DayAdded);


            //return Ok(response);
            // Here im using the CreatedAtAction method
            return CreatedAtAction(nameof(CreateItem),//the first parameter is the action in which the client can get the resource 
            new{id = item.Id},//
            response);
        }

        //When this endpoint is called we create an instance of the class in which we have the methods for our "database"
        //Then, when we get the item with the given id we create a response and feed it back to the client
        [HttpGet("{id:guid}")]
        public IActionResult GetItem(Guid id)
        {
            ErrorOr<Item> getItemResult = _itemService.GetItem(id);
            
            //We need this if to tell if the result of the GetItem method is a list of errors or an item object
            if(getItemResult.IsError && getItemResult.FirstError == Errors.Items.NotFound){
                //if this is true then the error we got was a not found error
                return NotFound();
            }

            //We are clear of errors and we use the Value property to get the item that was requested
            Item item = getItemResult.Value;

            
            CreateItemResponse response = new CreateItemResponse(item.Id,item.Name,item.Discription,item.Price,item.DayAdded);
            return Ok(response);
        }

        //Here we create an item and again using the interface send the item to the "database"
        [HttpPut("{id:guid}")]
        public IActionResult UpdateItem(Guid id, UpdateItem request)
        {
            Item item = new Item(id,request.name,request.discription,request.price,request.dayAdded);
            _itemService.UpdateItem(item);
            //TODO return 201 if a new item was created
            return NoContent();
        }

        //Here we will search for the item in question and if it exists delete it
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteItem(Guid id)
        {
            _itemService.DeleteItem(id);
            return NoContent();
        }
    }
