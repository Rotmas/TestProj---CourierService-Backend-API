namespace CourierService;

public record OrderCreateRequest
{
    public required int ItemId { get; init; }
    public required string DeliveryAddress { get; init; }
    public required DateTime DeliveryDate { get; init; }
}
