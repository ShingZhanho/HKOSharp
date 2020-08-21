## LocalWeatherForecast Class

Deserializes local weather forecast JSON data and save to its fields.

```c#
public class LocalWeatherForecast
```

### Constructors

| Signature                                                    | Description                                                  |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [LocalWeatherForecast(string)](LocalWeatherForecast_Constructors) | Initialized a new instance of the LocalWeatherForecast object to a specified JSON string. |

### Fields

| Name                | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| GeneralSituation    | Represents the general situation. This field is read-only.   |
| TropicalCycloneInfo | Represents the tropical cyclone information. This field is read-only. |
| FireDangerWarning   | Represents the fire danger warning message. This field is read-only. |
| ForecastPeriod      | Represents the forecast period. This field is read-only.     |
| ForecastDesc        | Represents the forecast description. This field is read-only. |
| Outlook             | Represents the outlook of today. This field is read-only.    |
| UpdateTime          | Represents the time of when this forecast is updated.        |

### Remarks

This class is used internally by LibHKOSharp. You should call methods in LibHKOSharp to get a LocalWeatherForecast object.