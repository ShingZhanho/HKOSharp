## LocalWeatherForecast Constructors

### LocalWeatherForecast(string)

Instantizes a new instance of the LocalWeatherForecast object to the specified JSON string.

```c#
internal LocalWeatherForecast(string json);
```

#### Parameters

`json` string

A string that contains JSON to be deserialized.

#### Remarks

LocalWeatherForecast can only be instantized within the assembly. 