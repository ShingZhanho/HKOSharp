## LocalWeatherForecast Constructors

### LocalWeatherForecast(string)

Initializes a new instance of the LocalWeatherForecast object to the specified JSON string.

```c#
public LocalWeatherForecast(string json);
```

#### Parameters

`json` string

A string that contains JSON to be deserialized.

#### Remarks

Parsing invalid or inappropriate JSON will cause problems.