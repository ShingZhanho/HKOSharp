## NineDaysWeather Class

Contains all info of future nine days' forecast.

```c#
public class NineDaysWeather
```

### [Constructors](NineDaysWeather_Constructors)

| Name                    | Description                                                  |
| ----------------------- | ------------------------------------------------------------ |
| NineDaysWeather(string) | Instantizes a new instance of the NineDaysWeather object to a specified JSON string. |

### Fields

| Name                                    | Description                                                  |
| --------------------------------------- | ------------------------------------------------------------ |
| GeneralSituation (`string`)             | Represents general situation.                                |
| WeatherForecast (`List<OneDayWeather>`) | A list of [OneDayWeather](OneDayWeather) objects. Contains future nine days' weather forecasts. |
| UpdateTime (`DateTime`)                 | Represents the update time of the current weather information. |
| SeaTemp (`SeaTemp`)                     | [SeaTemp](SeaTemp) object represents the information about sea temperature. |
| SoilTemps (`List<SoilTemp>`)            | A list of [SoilTemp](SoilTemp) objects. Contains soil temperatures measured from different stations. |

### Remarks

This class is used internally within LibHKOSharp. You should call methods in LibHKOSharp to get a NineDaysWeather object.