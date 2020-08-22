## SoilTemp Class

Contains all info of soil temperature.

```c#
public class SoilTemp : SeaTemp
```

### Inheritance

Object / [SeaTemp](SeaTemp) / SoilTemp

### [Constructors](SoilTemp_Constructors)

| Name             | Description                                                  |
| ---------------- | ------------------------------------------------------------ |
| SoilTemp(string) | Instantizes a new instance of the SoilTemp object to a specified JSON string. |

### Fields

| Name                    | Description                                                  |
| ----------------------- | ------------------------------------------------------------ |
| Place (`string`)        | Represents where the soil temperature is measured. Language depends on [Language](Language) parameter in [GetNineDaysWeather()](LibHKOSharp_Weather_GetNineDaysWeather) or [GetNineDaysWeatherAsync()](LibHKOSharp_Weather_GetNineDaysWeatherAsync) methods. |
| Temp (`double`)         | Represents the soil temperature (in degrees Celsius).        |
| RecordTime (`DateTime`) | Represents the record time of the soil temperature.          |
| Depth (`double`)        | Represents how deep is the soil temperature measured (in metre(s)). |

### Remarks

This class is used internally within LibHKOSharp. You should call methods in LibHKOSharp to get SoilTemp object.