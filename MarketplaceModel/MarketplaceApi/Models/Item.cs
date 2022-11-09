using ErrorOr;
using MarketplaceApi.ServiceErrors;

namespace MarketplaceApi.Models
{
    //This class will essentially be used to use item objects that we can extract from the http requests that the controllers get
    public class Item
    {
        const int minNameLength = 3;
        const int maxNameLength=20;
        const int minDiscriptionLength = 4;
        const int maxDiscriptionLength = 30;
        const decimal minPrice = 0;
        Guid id;
        String name;
        string discription;
        decimal price;
        DateTime dayAdded;

        public Guid Id { get => id;}
        public string Name { get => name;}
        public string Discription { get => discription;}
        public decimal Price { get => price;}
        public DateTime DayAdded{get => dayAdded;}

        private Item(Guid Aid, string Aname, string Adiscription , decimal Aprice, DateTime AdayAdded){
            id=Aid;
            name=Aname;
            discription=Adiscription;
            price=Aprice;
            dayAdded=AdayAdded;
        }

        public static ErrorOr<Item> Create(string Aname, string Adiscription, decimal Aprice, DateTime AdayAdded){

            List<Error> errors = new List<Error>();

            if(Aname.Length < minNameLength || Aname.Length > maxNameLength){
                errors.Add(Errors.Items.InvalidName);
            }

            if(Adiscription.Length < minDiscriptionLength || Adiscription.Length > maxDiscriptionLength){
                errors.Add(Errors.Items.InvalidDiscription);
            }

            if(Aprice <= minPrice){
                errors.Add(Errors.Items.InvalidPrice);
            }

            if(errors.Count>0){

                return errors;
            }
            return new Item(Guid.NewGuid(), Aname, Adiscription,Aprice,AdayAdded );
        }

    }
}