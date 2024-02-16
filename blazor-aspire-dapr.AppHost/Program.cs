var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.blazor_aspire_dapr_ApiService>("apiservice");

builder.AddProject<Projects.blazor_aspire_dapr_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
