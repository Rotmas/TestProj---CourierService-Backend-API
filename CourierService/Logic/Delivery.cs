using Model;

namespace Logic;

public class Delivery
{
    readonly PostalCode PostalCode;
    const decimal CostPerKilometer = 5;
    const double EarthRadiusKm = 6371.0;
    const string WarehousePostalCode = "198255";

    public Delivery(PostalCode postalCodeService)
        => PostalCode = postalCodeService;

    public decimal CalculateCost(string postalCode)
    {
        var location1 = PostalCode.GetLocation(WarehousePostalCode);
        var location2 = PostalCode.GetLocation(postalCode);

        var distance = GetDistance(location1, location2);

        return distance * CostPerKilometer;
    }

    static decimal GetDistance((double Latitude, double Longitude) firstLocation, (double Latitude, double Longitude) secondLocation)
    {
        var firstLatitudeInRadians = ConvertDegreesToRadians(firstLocation.Latitude);
        var firstLongitudeInRadians = ConvertDegreesToRadians(firstLocation.Longitude);
        var secondLatitudeInRadians = ConvertDegreesToRadians(secondLocation.Latitude);
        var secondLongitudeInRadians = ConvertDegreesToRadians(secondLocation.Longitude);

        var latitudeDifference = secondLatitudeInRadians - firstLatitudeInRadians;
        var longitudeDifference = secondLongitudeInRadians - firstLongitudeInRadians;

        var haversineOfCentralAngle =
               Math.Sin(latitudeDifference / 2) * Math.Sin(latitudeDifference / 2) +
               Math.Cos(firstLatitudeInRadians) * Math.Cos(secondLatitudeInRadians) *
               Math.Sin(longitudeDifference / 2) * Math.Sin(longitudeDifference / 2);

        var centralAngle = 2 * Math.Atan2(Math.Sqrt(haversineOfCentralAngle), Math.Sqrt(1 - haversineOfCentralAngle));

        return Math.Round(Convert.ToDecimal(EarthRadiusKm * centralAngle), 2);
    }
    static double ConvertDegreesToRadians(double degrees)
        => Math.PI * degrees / 180.0;

}
