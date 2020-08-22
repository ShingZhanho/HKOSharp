## Weather.GetLocalWeatherForecast Method

```c#
public static LocalWeatherForecast GetLocalWeatherForecast(Language language);
```

### Parameters

`language` [Language](Language)

Language of information wanted.

### Returns

[LocalWeatherForecast](LocalWeatherForecast)

An object that contains the extracted JSON information from HKO API. If failed, null is returned.

### Remarks

This method will block the calling thread.