using LoanCalculator.Common;

namespace LoanCalculator.ApiService.Weather;

public interface IWeatherService
{
    WeatherForecast[] GetWeatherForecasts();
}
