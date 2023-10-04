using Logic;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CourierService;

[ApiController]
[Route("/api/[controller]")]
public class OrdersController
{
    readonly Orders Orders;

    public OrdersController(Orders orders)
        => Orders = orders;

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var orders = await Orders.List();
        return new OkObjectResult(orders.Select(ToOrderInformationResponse).ToArray());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderInformationById(int id)
    {
        var orderInformation = await Orders.GetOrderInformationById(id);
        return new OkObjectResult(orderInformation);
    }

    static OrderInformationResponse ToOrderInformationResponse(OrderInformation order)
        => new()
        {
            DeliveryAddress = order.DeliveryAddress,
            DeliveryDate = order.DeliveryDate,
            ItemDescription = order.ItemDescription,
            ItemId = order.ItemId,
        };

    [HttpPost]
    public async Task<IActionResult> Create(OrderCreateRequest request)
    {
        var orderId = await Orders.Create(request.ItemId, request.DeliveryDate, request.DeliveryAddress);
        return new OkObjectResult(orderId);
    }
}