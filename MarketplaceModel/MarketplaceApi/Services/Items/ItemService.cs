using ErrorOr;
using MarketplaceApi.Models;
using MarketplaceApi.ServiceErrors;

namespace MarketplaceApi.Services.Items
{
    //Implementing the interface, this would be used to store items in the database but in this example we are storing them in memory
    //In general this class is used to implement the methods of the interface 
    public class ItemService : IitemService
    {
        //Dictionaries in c# are kinda like hash maps, key and value
        //It is also static cause we dont want it to be created again every time we create an object(we want only one Dictionary for all requests)
        private static readonly Dictionary<Guid,Item> _items = new();

        public ErrorOr<Created> CreateItem(Item item)
        {
            //Here we have the item id as a key and the object as the value 
            _items.Add(item.Id,item);
            return Result.Created;
        }

        //Removing the item with a specific id
        public ErrorOr<Deleted> DeleteItem(Guid id)
        {
            _items.Remove(id);
            return Result.Deleted;
        }

        //Returning the item which has a specific id
        public ErrorOr<Item> GetItem(Guid id){
            //The error or package just converts the objects from items to errors
            //Here we check if the dictionary contains an item with a specific id and if it does it returns it, otherwise it returns an error object
            if(_items.TryGetValue(id,out var item)){//out var is used to pass an item by reference without initializing it
                return item;
            }
            return Errors.Items.NotFound;
            
        }

        public ErrorOr<List<Item>> GetItems(){
            List<Item> items = new List<Item>();
            foreach (var item in _items){
                items.Add(item.Value);
            }
            if(items.Count == 0){
                return Errors.Items.EmptyDatabase;
            }
            return items;
        }

        //Simply adding the new item to the dictionary
        public ErrorOr<Updated> UpdateItem(Item item)
        {
            _items.Remove(item.Id);
            _items.Add(item.Id,item);
            return Result.Updated;
        }
    }
}