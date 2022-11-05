using MarketplaceApi.Models;
namespace MarketplaceApi.Services.Items
{
    //Implementing the interface, this would be used to store items in the database but in this example we are storing them in memory
    //In general this class is used to implement the methods of the interface 
    public class ItemService : IitemService
    {
        //Dictionaries in c# are kinda like hash maps, key and value
        //It is also static cause we dont want it to be created again every time we create an object(we want only one Dictionary for all requests)
        private static readonly Dictionary<Guid,Item> _items = new();

        public void CreateItem(Item item)
        {
            //Here we have the item id as a key and the object as the value 
            _items.Add(item.Id,item);
        }

        //Removing the item with a specific id
        public void DeleteItem(Guid id)
        {
            _items.Remove(id);
        }

        //Returning the item which has a specific id
        public Item GetItem(Guid id){
            return _items[id];
        }

        //Simply adding the new item to the dictionary
        public void UpdateItem(Item item)
        {
            _items[item.Id] = item;
        }
    }
}