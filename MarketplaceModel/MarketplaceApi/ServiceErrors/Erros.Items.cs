//This file is used for error handling, i added the ErrorOr package help with error handling
//The error package returns either an item object or a list of errors
namespace MarketplaceApi.ServiceErrors;
using ErrorOr;
using MarketplaceApi.Models;
public static class Errors{

    public static class Items{
        //Here we are creating the errors that will probably happen in our system reguarding the items 
        
        public static Error InvalidName => Error.Validation(code:"Item.Invalid",description:"The name entered was invalid");
        public static Error InvalidDiscription => Error.Validation(code:"Item.Invalid",description:"The discription entered was invalid");
        public static Error InvalidPrice => Error.Validation(code:"Item.Invalid",description:$"The price of an item must be more than 0.1 $");
        
        public static Error NotFound => Error.NotFound(code:"Item.NotFound",description:"The item requested was not found in the database");
        //the error object comes from the ErrorOr package, every error has a code, a description and a type
        public static Error EmptyDatabase =>Error.NotFound(code:"Item.NotFound",description:"There are currently no items in the database");
    }

}
