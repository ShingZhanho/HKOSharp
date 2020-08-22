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
        internal LocalWeatherForecast(string json) {
            ProcessJson(json);
        }

        #region Fields

        /// <summary>
        /// Represents the general situation.
        /// </summary>
        public string GeneralSituation { get; private set; }
        /// <summary>
        /// Represents the tropical cyclone information.
        /// </summary>
        public string TropicalCycloneInfo { get; private set; }
        /// <summary>
        /// Represents the fire danger warning information.
        /// </summary>
        public string FireDangerWarning { get; private set; }
        /// <summary>
        /// Represents the forecast period.
        /// </summary>
        public string ForecastPeriod { get; private set; }
        /// <summary>
        /// Represents the forecast description.
        /// </summary>
        public string ForecastDesc { get; private set; }
        /// <summary>
        /// Represents the outlook information.
        /// </summary>
        public string Outlook { get; private set; }
        /// <summary>
        /// Represents when all the information is updated.
        /// </summary>
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

        /// <summary>
        /// Returns a string of this object's summary
        /// </summary>
        public override string ToString() {
            var text = "";

            text += $"General Situation: {GeneralSituation}\n";
            text += $"Tropical Cyclone Info: {TropicalCycloneInfo}\n";
            text += $"Fire Danger Warning: {FireDangerWarning}\n";
            text += $"Forecast Period: {ForecastPeriod}\n";
            text += $"Forecast Description: {ForecastDesc}\n";
            text += $"Outlook: {Outlook}\n";
            text += $"Update date: {UpdateTime}";

            return text;
        }

        #endregion
    }
}