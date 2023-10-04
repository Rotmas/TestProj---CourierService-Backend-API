using Model;

namespace CourierService.Tests;

public class OrdersTests : TestBase
{
    [Fact]
    public async Task ReturnsEmptyListOfOrdersWhenNoOrdersWereMade()
    {
        var orders = await Api.Orders.List();
        Assert.Empty(orders);
    }

    [Fact]
    public async Task ReturnInformationOfOrderAfterOrderIsCreatedById()
    {
        var deliveryDate = DateTime.Now;
        var itemId = await Server<ItemRepository>().Create("Cola");
        await Api.Orders.Create(
            new OrderCreateRequest
            {
                ItemId = itemId,
                DeliveryAddress = "12345",
                DeliveryDate = deliveryDate
            });
        var orderInformation = await Api.Orders.Get(1);
        Assert.Equal(new OrderInformationResponse
        {
            DeliveryAddress = "12345",
            DeliveryDate = deliveryDate,
            ItemDescription = "Cola",
            ItemId = itemId
        }, orderInformation);
    }

    [Fact]
    public async Task ReturnSingleOrderAfterOrderIsCreated()
    {
        var deliveryDate = DateTime.Now;
        var itemId = await Server<ItemRepository>().Create("Cola");
        await Api.Orders.Create(
            new OrderCreateRequest
            {
                ItemId = itemId,
                DeliveryAddress = "12345",
                DeliveryDate = deliveryDate
            });
        var orders = await Api.Orders.List();
        Assert.Single(orders);
        var order = orders.Single();
        Assert.Equal(new OrderInformationResponse
        {
            DeliveryAddress = "12345",
            DeliveryDate = deliveryDate,
            ItemDescription = "Cola",
            ItemId = itemId
        }, order);
    }
}