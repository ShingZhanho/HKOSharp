using System;

namespace HKOSharp {
    namespace LibHKOSharp {
        /// <summary>
        /// Handles access to HKO's API for weather-related information.
        /// </summary>
        public static class Weather {
            // public methods

            public static LocalWeatherForecast GetLocalWeatherForecast(Language language) {
                var json = HttpRequest(GenerateRequestUrl(language, WeatherDataType.LocalWeatherForecast));
                return string.IsNullOrEmpty(json) ? null : new LocalWeatherForecast(json);
            }
            
            
            // private methods
            private static string GenerateRequestUrl(Language language, WeatherDataType dataType) {
                var url = "https://data.weather.gov.hk/weatherAPI/opendata/weather.php?";

                url += language switch {
                    Language.English => "lang=en",
                    Language.TraditionalChinese => "lang=tc",
                    Language.SimplifiedChinese => "lang=sc"
                };

                url += dataType switch {
                    WeatherDataType.LocalWeatherForecast => "&dataType=flw",
                };

                return url;
            }

            private static string HttpRequest(string url) {
                return null;
            }
        }
    }
}