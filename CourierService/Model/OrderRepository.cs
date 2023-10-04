namespace Model;

public interface OrderRepository
{
    Task<int> Create(int itemId, DateTime deliveryDate, string deliveryAddress);
    Task<OrderInformation> Get(int id);
    Task<OrderInformation[]> List();
}
