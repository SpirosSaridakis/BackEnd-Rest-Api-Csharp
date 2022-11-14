using ErrorOr;
using MarketplaceApi.Models;
namespace MarketplaceApi.Services.Items
//This is an interface that will be used for dependency injection in order for the application to communicate with the database
//In general here we define methods that our controllers will call depending on the request sent to our server
//All the methods we declare here will return a response that will be used for error handling 
{
    public interface IitemService
    {
        ErrorOr<Created> CreateItem(Item item);

        // Since an error might occure with this method, we use ErrorOr and it will either return an error or an item object
        ErrorOr<Item> GetItem(Guid id);

        ErrorOr<List<Item>> GetItems(); 

        ErrorOr<Deleted> DeleteItem(Guid id);

        ErrorOr<Updated> UpdateItem(Item item);

    }
}