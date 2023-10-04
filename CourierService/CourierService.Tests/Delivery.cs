using System.Net.Http.Json;

namespace CourierService.Tests;

public class Delivery
{
    readonly HttpClient Client;

    public Delivery(HttpClient client)
        => Client = client;

    public async Task<decimal> CalculateCost(string postalCode)
        => await Client.GetFromJsonAsync<decimal>($"/api/delivery/{postalCode}");
}