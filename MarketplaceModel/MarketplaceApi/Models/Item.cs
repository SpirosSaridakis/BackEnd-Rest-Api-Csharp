namespace MarketplaceApi.Models
{
    //This class will essentially be used to use item objects that we can extract from the http requests that the controllers get
    public class Item
    {
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

        public Item(Guid Aid, string Aname, string Adiscription , decimal Aprice, DateTime AdayAdded){
            id=Aid;
            name=Aname;
            discription=Adiscription;
            price=Aprice;
            dayAdded=AdayAdded;
        }

    }
}