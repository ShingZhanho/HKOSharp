using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    /// <summary>
    /// Contains fetched information of Local Weather Forecast. Don't initialize in your code.
    /// </summary>
    public class LocalWeatherForecast {
        
        /// <summary>
        /// Initializes a new LocalWeatherForecast instance
        /// </summary>
        /// <param name="json">JSON of data for this instance</param>
        public LocalWeatherForecast(string json) {
            ProcessJson(json);
        }

        #region Fields

        public string GeneralSituation { get; private set; }
        public string TropicalCycloneInfo { get; private set; }
        public string FireDangerWarning { get; private set; }
        public string ForecastPeriod { get; private set; }
        public string ForecastDesc { get; private set; }
        public string Outlook { get; private set; }
        public DateTime UpdateTime { get; private set; }

        #endregion

        #region Methods

        private void ProcessJson(string json) {
            var jo = (JObject) JsonConvert.DeserializeObject(json);
            if (jo == null) throw new NullReferenceException();
            GeneralSituation = jo["generalSituation"]?.ToString();
            TropicalCycloneInfo = jo["tcInfo"]?.ToString();
            FireDangerWarning = jo["fireDangerWarning"]?.ToString();
            ForecastPeriod = jo["forecastPeriod"]?.ToString();
            ForecastDesc = jo["forecastDesc"]?.ToString();
            Outlook = jo["outlook"]?.ToString();

            var updateTime = jo["updateTime"]?.ToString();
            UpdateTime = DateTime.Parse(updateTime);
        }

        #endregion
    }
}