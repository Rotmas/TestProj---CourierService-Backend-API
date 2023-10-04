namespace CourierService.Tests;

public class Api
{
    public readonly Delivery Delivery;
    public readonly Orders Orders;

    public Api(Delivery delivery, Orders orders)
        => (Delivery, Orders)
        = (delivery, orders);
}
