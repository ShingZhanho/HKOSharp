## OneDayWeather Class

Contains all info of one day's forecast.

```c#
public class OneDayWeather
```

### [Constructors](OneDayWeather_Constructors)

| Name                  | Description                                                  |
| --------------------- | ------------------------------------------------------------ |
| OneDayWeather(string) | Instantizes a new instance of the OneDayWeather object to a specified JSON string. |

### Fields

| Name                       | Description                                                  |
| -------------------------- | ------------------------------------------------------------ |
| ForecastDate (`DateTime`)  | Represents forecast date.                                    |
| Week (`string`)            | Represents the day of week (Saturday, Monday, etc.) (Language depends on [Language](Language) parameter in [GetNineDaysWeather()](LibHKOSharp_Weather_GetNineDaysWeather) or [GetNineDaysWeatherAsync()](LibHKOSharp_Weather_GetNineDaysWeatherAsync) methods). |
| ForecastWind (`string`)    | Represents the wind forecast of that day.                    |
| ForecastWeather (`string`) | Represents the weather forecast of that day.                 |
| ForecastMaxTemp (`double`) | Represents the maximum temperature of that day (in degrees Celsius). |
| ForecastMinTemp (`double`) | Represents the minimum temperature of that day (in degrees Celsius). |
| ForecastMaxRh (`double`)   | Represents the maximum relative humidity of that day (in percent). |
| ForecastMinRh (`double`)   | Represents the minimum relative humidity of that day (in percent). |
| ForecastIcon (`int`)       | Represents the number of the forecast icon of that day. See [Hong Kong Observatory's website](https://www.hko.gov.hk/textonly/v2/explain/wxicon_c.htm) about forecast icons. |

### Remarks

This class is used internally within LibHKOSharp. You should call methods in LibHKOSharp to get a OneDayWeather object.