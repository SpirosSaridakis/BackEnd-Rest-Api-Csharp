namespace MarketplaceModel.Contracts.Items;

public record UpdateItem(
    string name,
    string discription,
    decimal price,
    DateTime dayAdded);

