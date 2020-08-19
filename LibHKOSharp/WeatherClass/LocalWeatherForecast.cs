namespace LibHKOSharp {
    public class LocalWeatherForecast {
        
        /// <summary>
        /// Initializes a new LocalWeatherForecast instance
        /// </summary>
        /// <param name="json">JSON of data for this instance</param>
        public LocalWeatherForecast(string json) {
            
        }

        #region Fields

        public string GeneralSituation { get; private set; }
        public string TropicalCycloneInfo { get; private set; }

        #endregion
    }
}