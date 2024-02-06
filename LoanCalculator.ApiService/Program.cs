using FastEndpoints;
using LoanCalculator.ApiService.LoanCalculator;
using LoanCalculator.ApiService.Weather;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.SetIsOriginAllowed(origin =>
            new Uri(origin).Host == "localhost");
    });
        
});

//Using Transient as it's stateless & short-lived. Use Scoped if state matters, e.g. calling DB.
builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddTransient<ILoanCalculatorService, LoanCalculatorService>();

builder.Services.AddFastEndpoints();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

//Add Swagger for Dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapDefaultEndpoints();

app.UseFastEndpoints();

app.Run();
