using FastEndpoints;
using LoanCalculator.Common;

namespace LoanCalculator.ApiService.Weather;

public class WeatherForecastEndpoint : EndpointWithoutRequest<WeatherForecast[]>
{
    private readonly IWeatherService _weatherService;

    public WeatherForecastEndpoint(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public override void Configure()
    {
        Get("/weatherforecast");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendOkAsync(_weatherService.GetWeatherForecasts(), ct);
    }
}
