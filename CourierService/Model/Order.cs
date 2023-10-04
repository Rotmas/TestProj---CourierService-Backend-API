namespace Model;

public class Order
{
    public required int Id { get; set; }
    public required int ItemId { get; init; }
    public required DateTime DeliveryDate { get; init; }
    public required string DeliveryAddress { get; init; }
}
