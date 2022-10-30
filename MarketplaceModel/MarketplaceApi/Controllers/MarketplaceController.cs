using MarketplaceModel.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
namespace MarketplaceApi.Controllers;

    [ApiController]
    public class MarketplaceController : ControllerBase
    {
        [HttpPost("/CreateItem")]
        public IActionResult CreateItem(CreateItemRequest request)
        {
            return Ok(request);
        }

        [HttpGet("/CreateItem/{id:guid}")]
        public IActionResult GetItem(Guid id)
        {
            return Ok(id);
        }

        [HttpPut("/CreateItem/{id:guid}")]
        public IActionResult InsertItem(Guid id, UpdateItem request)
        {
            return Ok(request);
        }

        [HttpDelete("/CreateItem/{id:guid}")]
        public IActionResult DeleteItem(Guid id)
        {
            return Ok(id);
        }
    }
