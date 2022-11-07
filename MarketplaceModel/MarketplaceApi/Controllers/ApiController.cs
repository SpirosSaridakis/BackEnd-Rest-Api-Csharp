using ErrorOr;
using Microsoft.AspNetCore.Mvc;
/*This controller is used to inherit to the other controllers some methods*/
namespace MarketplaceApi.Controllers
{
    [ApiController]
    [Route("/CreateItem")]//This makes it so that every request needs to start with /CreateItem and then the methods just expand the route
    public class ApiController : ControllerBase
    {
        /*This function is used to identify a problem with a given request*/
        protected IActionResult Problem(List<Error> errors){
            Error firstError = errors[0];

            /*This creates a variable that will contain the status code of the problem that was encountered*/
            var statusCode = firstError.Type switch{
                /*we use a switch with lamba expressions so, given the errortype, the variable will contain the apropriate error code*/
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                //this means if non of the above, then it is an internal server error
                _ => StatusCodes.Status500InternalServerError
            };

            //Here we call the internal Problem method with the status code and title of our error, so that it can be sent back to the client
            return Problem(statusCode : statusCode , title : firstError.Description);

        }
        
    }
}