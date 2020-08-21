using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    /// <summary>
    /// Contains all info of future nine days' forecast. Don't initialize in your code.
    /// </summary>
    public class NineDaysWeather {
        #region Constructors

        internal NineDaysWeather(string json) {
            ParseJson(json);
        }

        #endregion

        #region Fields

        public string GeneralSituation { get; private set; }
        public List<OneDayWeather> WeatherForecast { get; private set; }
        public DateTime UpdateTime { get; private set; }
        public SeaTemp SeaTemp { get; private set; }
        public List<SoilTemp> SoilTemps { get; private set; }

        #endregion

        #region Methods

        private void ParseJson(string json) {
            // Deserialize JSON and put value into fields
            var jo = (JObject) JsonConvert.DeserializeObject(json);
            if (jo == null) throw new NullReferenceException();

            GeneralSituation = jo["generalSituation"]?.ToString();

            var dateString = jo["updateTime"]?.ToString();
            UpdateTime = DateTime.Parse(dateString);
            
            SeaTemp = new SeaTemp(jo);

            for (var i = 0; i < 9; i++) {
                var item = new OneDayWeather(jo["weatherForecast"]?[i]?.ToString());
                WeatherForecast.Add(item);
            }

            var jsonSoilTemp = jo["soilTemp"]?.ToString();
            var joSoilTemp = (JObject) JsonConvert.DeserializeObject(
                jsonSoilTemp.Substring(1, jsonSoilTemp.Length - 2));
            for (var i = 0; i < joSoilTemp.Count; i++) {
                var item = new SoilTemp(joSoilTemp["soilTemp"]?[i]?.ToString());
                SoilTemps.Add(item);
            }
        }

        #endregion
    }

    public class OneDayWeather {
        #region Constructors

        internal OneDayWeather(string json) {
            ParseJson(json);
        }

        #endregion

        #region Fields

        public string ForecastDate { get; private set; }
        public string Week { get; private set; }
        public string ForecastWind { get; private set; }
        public string ForecastWeather { get; private set; }
        public double ForecastMaxTemp { get; private set; }
        public double ForecastMinTemp { get; private set; }
        public double ForecastMaxRh { get; private set; }
        public double ForecastMinRh { get; private set; }
        public int ForecastIcon { get; private set; }

        #endregion

        #region Methods

        private static void ParseJson(string json) {
            
        }

        #endregion
    }

    public class SeaTemp {
        #region Constructors

        internal SeaTemp(JObject jObject) {
            
        }

        protected SeaTemp() { }

        #endregion

        #region Fields

        public string Place { get; private set; }
        public double Temp { get; private set; }
        public DateTime RecordTime { get; private set; }

        #endregion
    }

    public class SoilTemp : SeaTemp {
        #region Constructors

        internal SoilTemp(string json)  {
            
        }

        #endregion

        #region Fields

        public double Depth { get; private set; }

        #endregion
    }
}