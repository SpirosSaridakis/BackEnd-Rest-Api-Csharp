/*Essentially this class is a controller that is used when we have an exception thrown, the request is re-routed to the /error endpoint and 
it just send back to the client that there was an error instead of the stacktrace and the info we have at the backend*/
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceApi.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error(){

            return Problem();//Returns 500 internal server error
        }
        
    }
}