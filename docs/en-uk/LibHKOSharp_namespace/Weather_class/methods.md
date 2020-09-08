# Weather class methods



## GetLocalWeatherForecast method :id=GetLoacalWeatherForecast



### Overload GetLocalWeatherForecast(Language) :id=GetLocalWeatherForecast_Language

Returns a LocalWeatherForecast object which contains all information about local weather forecast in specified language.

```c#
public static LocalWeatherForecast GetLocalWeatherForecast(Language language)
```

#### Parameters

`language` (enum) [Language]()

Represents which language of local weather forecast to get.

#### Returns

[LocalWeatherForecast]() object, if exception is thrown, null is returned.



## GetLocalWeatherForecastAsync method :id=GetLocalWeatherForecastAsync



### Overload GetLocalWeatherForecastAsync(Language) :id=GetLocalWeatherForecast_Language

Returns a task represents a get LocalWeatherForecast operation asynchronously.

```c#
public static async Task<LocalWeatherForecast> GetLocalWeatherForecast(Language language)
```

#### Parameters

`language` (enum) [Language]()

Represents which language of local weather forecast to get.

#### Returns

Task<[LocalWeatherForecast]()>.



## GetNineDaysWeather method :id=GetNineDaysWeather



### Overload GetNineDaysWeather(Language) :id=GetNineDaysWeather_Language

Returns a NineDaysWeather object which contains all information about future nine days' weather forecast.

```c#
public static NineDaysWeather GetNineDaysWeather(Language language)
```

#### Parameters

`language` (enum) [Language]()

Represents which language of 9-day weather forecast to get.

#### Returns

[NineDaysWeather]() object, if exception is thrown, null is returned.