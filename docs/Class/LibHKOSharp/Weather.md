## Weather Class

Handles information about forecasts, weather warning etc.

```c#
public static class Weather
```

### Methods

| Signature                                                    | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [GetLocalWeatherForecast(Language)](#GetLocalWeatherForecast Method) | Returns an LocalWeatherForecast object which includes extracted information about today's local weather forecast in specified language. |
| GetLocalWeatherForecastAsync(Language)                       | Returns an LocalWeatherForecast object which includes extracted information about today's local weather forecast in specified language asynchronously. |

#### GetLocalWeatherForecast Method

```c#
public void GetLocalWeatherForecast(Language language);
```

##### Parameters

`language` [Language]()

Language of information wanted.

##### Returns

[LocalWeatherForecast]()

An object that contains the extracted JSON information from HKO API.

##### Remarks

This method will block the calling thread.