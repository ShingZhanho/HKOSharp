## Weather.GetNineDaysWeather Method

```c#
public static NineDaysWeather GetNineDaysWeather(Language language);
```

### Parameters

`language` [Language](Language)

Language of information wanted.

### Returns

[NineDaysWeather](NineDaysWeather)

An object that contains the extracted JSON information from HKO API. If failed, null is returned.

### Remarks

This method will block the calling thread.