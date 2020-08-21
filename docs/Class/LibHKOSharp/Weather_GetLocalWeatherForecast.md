## Weather.GetLocalWeatherForecast Method

```c#
public void GetLocalWeatherForecast(Language language);
```

### Parameters

`language` [Language]()

Language of information wanted.

### Returns

[LocalWeatherForecast]()

An object that contains the extracted JSON information from HKO API.

### Remarks

This method will block the calling thread.