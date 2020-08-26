using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    namespace LibHKOSharp {
        /// <summary>
        /// Handles access to HKO's API for weather-related information.
        /// </summary>
        public static class Weather {
            // public methods

            /// <summary>
            /// Gets today's local weather forecast in specified language (English default).
            /// </summary>
            /// <param name="language">Language of forecast</param>
            /// <returns>LocalWeatherForecast if succeeded, null if failed.</returns>
            public static LocalWeatherForecast GetLocalWeatherForecast(Language language = Language.English) {
                var json = HttpRequest(GenerateRequestUrl(language, WeatherDataType.LocalWeatherForecast));
                return string.IsNullOrEmpty(json)
                    ? null
                    : JsonIsValid(json) 
                        ? new LocalWeatherForecast(json, language) 
                        : null;
            }

            /// <summary>
            /// Gets today's local weather forecast in specified language (English default) asynchronously.
            /// </summary>
            /// <param name="language">Language of forecast</param>
            /// <returns>A task represents the get local weather forecast action.</returns>
            public static async Task<LocalWeatherForecast> GetLocalWeatherForecastAsync(
                Language language = Language.English) {
                var json = 
                    await HttpRequestAsync(GenerateRequestUrl(language, WeatherDataType.LocalWeatherForecast));
                return string.IsNullOrEmpty(json)
                    ? null
                    : JsonIsValid(json)
                        ? new LocalWeatherForecast(json, language)
                        : null;
            }
            
            
            // private methods
            
            private static string GenerateRequestUrl(Language language, WeatherDataType dataType) {
                var url = "https://data.weather.gov.hk/weatherAPI/opendata/weather.php?";

                url += language switch {
                    Language.English => "lang=en",
                    Language.TraditionalChinese => "lang=tc",
                    Language.SimplifiedChinese => "lang=sc",
                    _ => "lang=en"
                };

                url += dataType switch {
                    WeatherDataType.LocalWeatherForecast => "&dataType=flw",
                };

                return url;
            }

            private static bool JsonIsValid(string json) {
                try {
                    JObject.Parse(json);
                }
                catch {
                    return false;
                }
                return true;
            }

            private static string HttpRequest(string url) {
                string response;
                try {
                    var request = WebRequest.Create(url);
                    request.Method = "GET";
                    using var responseStream = request.GetResponse().GetResponseStream();
                    using var reader = new StreamReader(responseStream);
                    response = reader.ReadToEnd();
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                    return null;
                }

                return response;
            }

            private static async Task<string> HttpRequestAsync(string url) {
                string response;
                try {
                    var request = WebRequest.Create(url);
                    request.Method = "GET";
                    WebResponse taskRequest;
                    using (taskRequest = await request.GetResponseAsync()) {
                        using (var responseStream = taskRequest.GetResponseStream()) {
                            using (var reader = new StreamReader(responseStream)) {
                                response = await reader.ReadToEndAsync();
                            }
                        }
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                    return null;
                }

                return response;
            }
        }
    }
}