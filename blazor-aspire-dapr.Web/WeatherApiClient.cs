namespace blazor_aspire_dapr.Web;

public class WeatherApiClient(HttpClient httpClient)
{
    public async Task<WeatherForecast[]> GetWeatherAsync()
    {
        return await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast") ?? [];
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


public class ShoppingCatalogApiClient(HttpClient httpClient)
{
    public async Task<CatalogItem[]> GetCatalogAsync()
    {
        return await httpClient.GetFromJsonAsync<CatalogItem[]>("/catalog") ?? [];
    }
}

public record CatalogItem(int ID, string Name, int Price, int AvailableQuantity)
{
}