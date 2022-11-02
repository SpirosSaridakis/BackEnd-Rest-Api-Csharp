using MarketplaceApi.Models;
namespace MarketplaceApi.Services.Items
//This is an interface that will be used for dependency injection in order for the application to communicate with the database
//In general here we define methods that our controllers will call depending on the request sent to our server
{
    public interface IitemService
    {
        void CreateItem(Item item);
        Item GetItem(Guid id);
    }
}