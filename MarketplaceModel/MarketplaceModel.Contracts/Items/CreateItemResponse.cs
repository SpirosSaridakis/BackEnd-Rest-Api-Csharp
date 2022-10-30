namespace MarketplaceModel.Contracts.Items;

public record CreateItemResponse(
    Guid id,
    string name,
    string discription,
    decimal price,
    DateTime dayAdded);

