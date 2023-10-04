using System.Net.Http.Json;

namespace CourierService.Tests;

public class Orders
{
    readonly HttpClient Client;

    public Orders(HttpClient client)
        => Client = client;

    public async Task<int> Create(OrderCreateRequest request)
    {
        var response = await Client.PostAsJsonAsync($"/api/orders", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<int>();
    }

    public async Task<OrderInformationResponse> Get(int id)
        => await Client.GetFromJsonAsync<OrderInformationResponse>($"/api/orders/{id}") ?? throw new Exception($"Order {id} not found");

    public async Task<OrderInformationResponse[]> List()
        => await Client.GetFromJsonAsync<OrderInformationResponse[]>($"/api/orders") ?? throw new Exception($"Unable to get list of orders");
}
