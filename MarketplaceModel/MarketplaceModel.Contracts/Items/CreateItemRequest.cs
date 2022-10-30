namespace MarketplaceModel.Contracts.Items;

public record CreateItemRequest(
    string name,
    string discription,
    decimal price,
    DateTime dayAdded);

