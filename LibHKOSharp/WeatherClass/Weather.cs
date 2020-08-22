// Weather.cs is file of Weather class under LibHKOSharp class

using System;
using System.IO;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    public partial class LibHKOSharp {
        public static class Weather {
            #region Fields

            private const string ApiUrl = "https://data.weather.gov.hk/weatherAPI/opendata/weather.php?";

            #endregion

            #region Methods

            /// <summary>
            /// Gets Local Weather Forecast in given language. This method will block the calling thread.
            /// </summary>
            /// <param name="language">Language of forecast to get</param>
            /// <returns>LocalWeatherForecast object if succeeded, null instead</returns>
            public static LocalWeatherForecast GetLocalWeatherForecast(Language language) {
                var requestUrl = ApiUrl;
                requestUrl += "dataType=flw";
                if (language == Language.English)
                    requestUrl += "&lang=en";
                else if (language == Language.TraditionChinese)
                    requestUrl += "&lang=tc";
                else if (language == Language.SimplifiedChinese) requestUrl += "&lang=sc";

                // Request and get response
                var response = HttpRequest(requestUrl);
                
                // Parse json to object and return
                return new LocalWeatherForecast(response);
            }
            
            /// <summary>
            /// Gets Local Weather Forecast in given language asynchronously.
            /// </summary>
            /// <param name="language">Language of forecast to get</param>
            /// <returns>LocalWeatherForecast object if succeeded, null instead</returns>
            public static async Task<LocalWeatherForecast> GetLocalWeatherForecastAsync(Language language) {
                var requestUrl = ApiUrl;
                requestUrl += "dataType=flw";
                if (language == Language.English)
                    requestUrl += "&lang=en";
                else if (language == Language.TraditionChinese)
                    requestUrl += "&lang=tc";
                else if (language == Language.SimplifiedChinese) requestUrl += "&lang=sc";

                // Request and get response asynchronously
                var response = await HttpRequestAsync(requestUrl);

                // Return
                return new LocalWeatherForecast(response);
            }

            /// <summary>
            /// Gets Nine-Day Weather Forecast in given language. This method will block the calling thread.
            /// </summary>
            /// <param name="language">Language of forecast to get</param>
            /// <returns>NineDaysWeather object if succeeded, null instead.</returns>
            public static NineDaysWeather GetNineDaysWeather(Language language) {
                var requestUrl = ApiUrl;
                requestUrl += "dataType=fnd";
                
                if (language == Language.English)
                    requestUrl += "&lang=en";
                else if (language == Language.TraditionChinese)
                    requestUrl += "&lang=tc";
                else if (language == Language.SimplifiedChinese) requestUrl += "&lang=sc";

                // Request and get response asynchronously
                var response =  HttpRequest(requestUrl);
                
                return !JsonIsValid(response) ? null : new NineDaysWeather(response);
            }

            #endregion

            #region Methods for internal use

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
                    return e.ToString();
                }

                return response;
            }

            private static bool JsonIsValid(string json) {
                try {
                    var jo = JObject.Parse(json);
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                    return false;
                }
                return true;
            }

            #endregion
        }
    }
}