using Logic;
using Microsoft.AspNetCore.Mvc;

namespace CourierService;

[ApiController]
[Route("/api/[controller]")]
public class DeliveryController
{
    readonly Delivery Delivery;

    public DeliveryController(Delivery delivery)
        => Delivery = delivery;

    [HttpGet("{postalCode}")]
    public ActionResult<decimal> GetDeliveryCost(string postalCode)
        => Delivery.CalculateCost(postalCode);
}
