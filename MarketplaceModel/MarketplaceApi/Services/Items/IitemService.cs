using ErrorOr;
using MarketplaceApi.Models;
namespace MarketplaceApi.Services.Items
//This is an interface that will be used for dependency injection in order for the application to communicate with the database
//In general here we define methods that our controllers will call depending on the request sent to our server
{
    public interface IitemService
    {
        void CreateItem(Item item);

        // Since an error might occure with this method, we use ErrorOr and it will either return an error or an item object
        ErrorOr<Item> GetItem(Guid id); 

        void DeleteItem(Guid id);

        void UpdateItem(Item item);

    }
}