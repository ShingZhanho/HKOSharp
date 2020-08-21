## LocalWeatherForecast Class

Deserializes local weather forecast JSON data and save to its fields.

```c#
public class LocalWeatherForecast
```

### [Constructors](LocalWeatherForecast_Constructors)

| Signature                    | Description                                                  |
| ---------------------------- | ------------------------------------------------------------ |
| LocalWeatherForecast(string) | Instantize a new instance of the LocalWeatherForecast object to a specified JSON string. |

### Fields

| Name                           | Description                                                  |
| ------------------------------ | ------------------------------------------------------------ |
| GeneralSituation (`string`)    | Represents the general situation. This field is read-only.   |
| TropicalCycloneInfo (`string`) | Represents the tropical cyclone information. This field is read-only. |
| FireDangerWarning (`string`)   | Represents the fire danger warning message. This field is read-only. |
| ForecastPeriod (`string`)      | Represents the forecast period. This field is read-only.     |
| ForecastDesc (`string`)        | Represents the forecast description. This field is read-only. |
| Outlook (`string`)             | Represents the outlook of today. This field is read-only.    |
| UpdateTime (`DateTime`)        | Represents the time of when this forecast is updated.        |

### Remarks

This class is used internally by LibHKOSharp. You should call methods in LibHKOSharp to get a LocalWeatherForecast object.