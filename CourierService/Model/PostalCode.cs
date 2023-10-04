namespace Model;

public interface PostalCode
{
    (double Latitude, double Longitude) GetLocation(string postalCode);
}
