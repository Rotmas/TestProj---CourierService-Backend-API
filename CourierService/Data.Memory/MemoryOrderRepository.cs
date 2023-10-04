using Model;

namespace Data.Memory;

public class MemoryOrderRepository : OrderRepository
{
    int LastOrderId = 1;
    readonly Dictionary<int, Order> Orders = new();
    readonly ItemRepository Items;

    public MemoryOrderRepository(ItemRepository items)
        => Items = items;

    public async Task<OrderInformation[]> List()
    {
        var orders = new List<OrderInformation>();
        foreach (var order in Orders.Values)
        {
            var item = await Items.Get(order.ItemId);
            var information = new OrderInformation
            {
                DeliveryAddress = order.DeliveryAddress,
                DeliveryDate = order.DeliveryDate,
                Id = order.Id,
                ItemId = order.ItemId,
                ItemDescription = item.Description
            };
            orders.Add(information);
        }
        return orders.ToArray();
    }

    public async Task<OrderInformation> Get(int id)
    {
        var order = Orders[id];
        var item = await Items.Get(order.ItemId);
        var information = new OrderInformation
        {
            DeliveryAddress = order.DeliveryAddress,
            DeliveryDate = order.DeliveryDate,
            Id = order.Id,
            ItemId = order.ItemId,
            ItemDescription = item.Description
        };
        return information;
    }

    public Task<int> Create(int itemId, DateTime deliveryDate, string deliveryAddress)
    {
        var order = new Order
        {
            Id = LastOrderId++,
            DeliveryAddress = deliveryAddress,
            DeliveryDate = deliveryDate,
            ItemId = itemId
        };
        Orders.Add(order.Id, order);
        return Task.FromResult(order.Id);
    }
}