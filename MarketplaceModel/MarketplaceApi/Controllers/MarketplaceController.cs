using MarketplaceModel.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
using MarketplaceApi.Models;
using MarketplaceModel.Services.Items;
namespace MarketplaceApi.Controllers;


[ApiController]
    [Route("/CreateItem")]//This makes it so that every request needs to start with /CreateItem and then the methods just expand the route
    public class MarketplaceController : ControllerBase
    {
        private readonly IitemService _itemService;
        [HttpPost()]
        public IActionResult CreateItem(CreateItemRequest request)
        {
            //Creating the Item object by getting the properties of the sent request that the controller recieves
            //Mapping the data that we get in the request to c#, which we use for our application
            Item item = new Item(Guid.NewGuid(),request.name,request.discription,request.price,request.dayAdded);

            //TODO save the item in the database


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

        [HttpGet("{id:guid}")]
        public IActionResult GetItem(Guid id)
        {
            return Ok(id);
        }

        [HttpPut("{id:guid}")]
        public IActionResult InsertItem(Guid id, UpdateItem request)
        {
            return Ok(request);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteItem(Guid id)
        {
            return Ok(id);
        }
    }
