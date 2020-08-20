// Weather.cs is file of Weather class under LibHKOSharp class

using System;
using System.IO;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Http;

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
            /// <param name="language">Language of forecast</param>
            /// <returns>LocalWeatherForecast object if succeeded, null instead</returns>
            public static LocalWeatherForecast GetLocalWeatherForecast(Language language) {
                var requestUrl = ApiUrl;
                requestUrl += "dataType=flw";
                switch (language) {
                    case Language.English:
                        requestUrl += "&lang=en";
                        break;
                    case Language.TraditionChinese:
                        requestUrl += "&lang=tc";
                        break;
                    case Language.SimplifiedChinese:
                        requestUrl += "&lang=sc";
                        break;
                }

                // Request and get response
                string response; // This is json response
                try {
                    var request = WebRequest.Create(requestUrl);
                    request.Method = "GET";
                    using (var responseStream = request.GetResponse().GetResponseStream()) {
                        using (var reader = new StreamReader(responseStream)) {
                            response = reader.ReadToEnd();
                            responseStream.Close();
                        }
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                    return null;
                }
                
                // Parse json to object and return
                return new LocalWeatherForecast(response);
            }

            #endregion
        }
    }
}