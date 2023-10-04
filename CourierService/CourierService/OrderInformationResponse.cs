namespace CourierService;

public record OrderInformationResponse : OrderCreateRequest
{
    public required string ItemDescription { get; init; }
}