## SeaTemp Class

Contains all info of sea temperature.

```c#
public class SeaTemp
```

### [Constructors](SeaTemp_Constructors)

| Name             | Description                                                  |
| ---------------- | ------------------------------------------------------------ |
| SeaTemp(JObject) | Instantizes a new instance of the SeaTemp object to a specified JSON object. |
| SeaTemp()        | Instantizes a new instance of the SeaTemp object that contains nothing. |

### Fields

| Name                    | Description                                                  |
| ----------------------- | ------------------------------------------------------------ |
| Place (`string`)        | Represents where the sea temperature is measured. Language depends on [Language](Language) parameter in [GetNineDaysWeather()](LibHKOSharp_Weather_GetNineDaysWeather) or [GetNineDaysWeatherAsync()](LibHKOSharp_Weather_GetNineDaysWeatherAsync) methods. |
| Temp (`double`)         | Represents the sea temperature (in degrees Celsius).         |
| RecordTime (`DateTime`) | Represents the record time of the sea temperature.           |

### Remarks

This class is used internally within LibHKOSharp. You should call methods in LibHKOSharp to get SeaTemp object.