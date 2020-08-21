## Weather.GetLocalWeatherForecast Method

```c#
public static LocalWeatherForecast GetLocalWeatherForecast(Language language);
```

### Overload

This method has no overload.

### Parameters

`language` [Language](Language)

Language of information wanted.

### Returns

[LocalWeatherForecast]()

An object that contains the extracted JSON information from HKO API. If failed, null is returned.

### Remarks

This method will block the calling thread.