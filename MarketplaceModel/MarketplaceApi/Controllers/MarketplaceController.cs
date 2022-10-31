using MarketplaceModel.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
namespace MarketplaceApi.Controllers;

    [ApiController]
    [Route("/CreateItem")]//This makes it so that every request needs to start with /CreateItem and then the methods just expand the route
    public class MarketplaceController : ControllerBase
    {
        [HttpPost()]
        public IActionResult CreateItem(CreateItemRequest request)
        {
            return Ok(request);
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
