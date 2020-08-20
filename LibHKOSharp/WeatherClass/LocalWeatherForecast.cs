using System;

namespace HKOSharp {
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
            
        }

        #endregion
    }
}