using Model;

namespace CourierService.Tests;

public class PostalCodeFake : PostalCode
{
    public (double Latitude, double Longitude) GetLocation(string postalCode) => postalCode switch
    {
        "198255" => (59.885, 29.896),
        "195427" => (59.932, 30.197),
        "677000" => (62.034, 129.733),
        _ => throw new NotImplementedException()
    };
}