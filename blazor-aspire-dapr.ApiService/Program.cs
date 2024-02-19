var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var groceryItems = new[]
{
    "Biscuits", "Bread", "Chilly Powder", "Rice Bag - 1KG", "Wheat Bag - 1KG", "Sugar Bag - 1KG", "Groundnut Bag - 1KG", "Protein Bar", "Chocolate", "Nutulla"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapGet("/catalog", () =>
{
    var forecast = Enumerable.Range(1, 10).Select(index =>
        new CatalogItem
        (
            index,
            groceryItems[index - 1],
            Random.Shared.Next(10, 105),
            Random.Shared.Next(10, 105)
        ))
        .ToArray();
    return forecast;
});

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public record CatalogItem(int ID, string Name, int Price, int AvailableQuantity)
{

}