namespace CourierService.Tests;

public class DeliveryTests : TestBase
{
    [Fact]
    public async Task ReturnsDeliveryCostToArbitraryPostalCode()
    {
        var costOfDeliveryToStPetersburg = await Api.Delivery.CalculateCost("195427");
        var costOfDeliveryToYakutsk = await Api.Delivery.CalculateCost("677000");
        Assert.True(costOfDeliveryToYakutsk > costOfDeliveryToStPetersburg * 10);
    }
}
