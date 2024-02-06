using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.SetIsOriginAllowed(origin =>
            new Uri(origin).Host == "localhost");
    });

});

var cache = builder.AddRedis("cache");

var apiService = builder
    .AddProject<Projects.LoanCalculator_ApiService>("calculatorapi")
    .WithLaunchProfile("https");

var blazorApp = builder
    .AddProject<Projects.LoanCalculator_Web>("blazorfe")
    .WithReference(apiService)
    .WithLaunchProfile("https")
    .WithReference(cache);

var ngApp = builder.AddNpmApp("ngApp", "../LoanCalculator.Angular")
    .WithReference(apiService)
    //.WithServiceBinding(containerPort: 4200, scheme: "http", env: "PORT");
    .WithServiceBinding(containerPort: 3000, scheme: "http", env: "PORT")
    .AsDockerfileInManifest();

builder.Build().Run();
