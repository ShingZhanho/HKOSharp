# Weather class

A class contains all methods for getting information about weather from HKO's API.

```c#
public static class Weather
```

## Methods

| Name                                                         | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [GetLocalWeatherForecast(Language)](methods#GetLocalWeatherForecast_Language) | Returns a LocalWeatherForecast object which contains all information about local weather forecast in the language specified. |
| [GetLocalWeatherForecastAsync(Language)](methods#GetLocalWeatherForecastAsync_Language) | Returns a task represents a get LocalWeatherForecast operation. |
| [GetNineDaysWeather(Language)](methods#GetNineNineDaysWeather_Language) | Returns a NineDaysWeather object which contains all information about future nine days' weather forecast in the language specified. |
| [GetNineDaysWeatherAsync(Language)](methods#GetNineDaysWeatherAsync_Language) | Returns a task represents a get NineDaysWeather operation.   |

