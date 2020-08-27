using System;

namespace HKOSharp {
    /// <summary>
    /// Represents three supported languages.
    /// </summary>
    public enum Language {
        English,
        TraditionalChinese,
        SimplifiedChinese
    }

    internal enum WeatherDataType {
        LocalWeatherForecast,
        NineDaysWeather
    }
}