using Model;

namespace Logic;

public class Orders
{
    readonly OrderRepository Repository;

    public Orders(OrderRepository repository)
        => Repository = repository;

    public Task<OrderInformation[]> List()
        => Repository.List();

    public Task<int> Create(int itemId, DateTime deliveryDate, string deliveryAddress)
        => Repository.Create(itemId, deliveryDate, deliveryAddress);

    public Task<OrderInformation> GetOrderInformationById(int id)
        => Repository.Get(id);
}