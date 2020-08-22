using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    /// <summary>
    /// Contains all info of future nine days' forecast.
    /// </summary>
    public class NineDaysWeather {
        #region Constructors

        internal NineDaysWeather(string json) {
            ParseJson(json);
        }

        #endregion

        #region Fields

        /// <summary>
        /// A string of general situation.
        /// </summary>
        public string GeneralSituation { get; private set; }
        /// <summary>
        /// A list of OneDayWeather objects. Contains future 9 days' weather forecasts.
        /// </summary>
        public List<OneDayWeather> WeatherForecast { get; private set; }
        /// <summary>
        /// Represents the time of this forecast was updated.
        /// </summary>
        public DateTime UpdateTime { get; private set; }
        /// <summary>
        /// A SeaTemp object. Contains information about sea temperature.
        /// </summary>
        public SeaTemp SeaTemp { get; private set; }
        /// <summary>
        /// A list of SoilTemp object. Contains information of soil temperature from different station.
        /// </summary>
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
        
        /// <summary>
        /// Represents the summary of all information.
        /// </summary>
        public override string ToString() {
            var returnString = "";

            returnString += $"Information updated at {UpdateTime}\n";
            returnString += $"General Situation: {GeneralSituation}\n";
            returnString += "Nine-day Forecast:\n";
            foreach (var day in WeatherForecast)
            foreach (var line in day.ToString().Split('\n'))
                returnString += $"    {line}\n";
            returnString += $"Sea temperature: {SeaTemp}\n";
            foreach (var soil in SoilTemps)
                returnString += $"Soil Temperature: {soil}";

            return returnString;
        }

        #endregion
    }

    /// <summary>
    /// Contains weather forecast information of a specific day.
    /// </summary>
    public class OneDayWeather {
        #region Constructors

        internal OneDayWeather(string json) {
            ParseJson(json);
        }

        #endregion

        #region Fields

        /// <summary>
        /// Represents the date of this forecast.
        /// </summary>
        public DateTime ForecastDate { get; private set; }
        /// <summary>
        /// A string which represents the day of a week: Monday, Saturday etc.
        /// Language depends on the language parameter.
        /// </summary>
        public string Week { get; private set; }
        /// <summary>
        /// A string which describes the wind of that day.
        /// </summary>
        public string ForecastWind { get; private set; }
        /// <summary>
        /// A string which describes the weather of that day.
        /// </summary>
        public string ForecastWeather { get; private set; }
        /// <summary>
        /// Represents the maximum temperature of that day (in degrees Celsius).
        /// </summary>
        public double ForecastMaxTemp { get; private set; }
        /// <summary>
        /// Represents the minimum temperature of that day (in degrees Celsius).
        /// </summary>
        public double ForecastMinTemp { get; private set; }
        /// <summary>
        /// Represents the highest relative humidity of that day (in percent).
        /// </summary>
        public double ForecastMaxRh { get; private set; }
        /// <summary>
        /// Represents the lowest relative humidity of that day (in percent).
        /// </summary>
        public double ForecastMinRh { get; private set; }
        /// <summary>
        /// Represents number of the forecast icon of that day.
        /// Check the list of forecast icons
        /// <see cref="https://www.hko.gov.hk/textonly/v2/explain/wxicon_c.htm">here</see>.
        /// </summary>
        public int ForecastIcon { get; private set; }

        #endregion

        #region Methods

        private void ParseJson(string json) {
            var jo = (JObject) JsonConvert.DeserializeObject(json);
            if (jo == null) throw new NullReferenceException();

            Week = jo["week"]?.ToString();
            ForecastWind = jo["forecastWind"]?.ToString();
            ForecastWeather = jo["forecastWeather"]?.ToString();
            
            ForecastMaxTemp = Convert.ToDouble(jo["forecastMaxtemp"]?.ToString());
            ForecastMinTemp = Convert.ToDouble(jo["forecastMintemp"]?.ToString());
            ForecastMaxRh = Convert.ToDouble(jo["forecastMaxrh"]?.ToString());
            ForecastMinRh = Convert.ToDouble(jo["forecastMinrh"]?.ToString());
            ForecastIcon = Convert.ToInt32(jo["ForecastIcon"]?.ToString());

            var dateString = jo["forecastDate"]?.ToString(); // format: yyyyMMdd
            ForecastDate = new DateTime(
                int.Parse(dateString.Substring(0,4)),
                int.Parse(dateString.Substring(3, 2)),
                int.Parse(dateString.Substring(5)));
        }

        #endregion

        public override string ToString() {
            var returnString = "";

            returnString += $"Forecast Date: {ForecastDate}\n";
            returnString += $"Day of week: {Week}\n";
            returnString += $"Wind Forecast: {ForecastWind}\n";
            returnString += $"Weather Forecast: {ForecastWeather}\n";
            returnString += $"Temperature: from {ForecastMinTemp}C to {ForecastMaxTemp}C\n";
            returnString += $"Relative Humidity: from {ForecastMinRh}% to {ForecastMaxRh}%\n";
            returnString += $"Icon: {ForecastIcon}";
            
            return returnString;
        }
    }

    /// <summary>
    /// Contains the information about the sea temperature.
    /// </summary>
    public class SeaTemp {
        #region Constructors

        internal SeaTemp(JObject jObject) {
            Place = jObject["seaTemp"]?["place"]?.ToString();
            Temp = Convert.ToDouble(jObject["seaTemp"]?["value"]?.ToString());
            RecordTime = DateTime.Parse(jObject["seaTemp"]?["recordTime"]?.ToString());
        }

        protected SeaTemp() { }

        #endregion

        #region Fields

        /// <summary>
        /// A string which represents the place's name which the sea/soil temperature is measured.
        /// </summary>
        public string Place { get; protected set; }
        /// <summary>
        /// Represents the sea/soil temperature (in degrees Celsius).
        /// </summary>
        public double Temp { get; protected set; }
        /// <summary>
        /// Represents the time which the sea/soil temperature is measured.
        /// </summary>
        public DateTime RecordTime { get; protected set; }

        #endregion

        #region Methods

        public override string ToString() {
            return $"Measured in {Place} at {RecordTime}. Temperature: {Temp}C";
        }

        #endregion
    }

    /// <summary>
    /// Contains information about the soil temperature.
    /// </summary>
    public class SoilTemp : SeaTemp {
        #region Constructors

        internal SoilTemp(string json) {
            var jo = (JObject) JsonConvert.DeserializeObject(json);
            if (jo == null) throw new NullReferenceException();

            Place = jo["place"]?.ToString();
            Temp = Convert.ToDouble(jo["value"]?.ToString());
            RecordTime = DateTime.Parse(jo["recordTime"]?.ToString());
            Depth = Convert.ToDouble(jo["depth"]?["value"]?.ToString());
        }

        #endregion

        #region Fields

        /// <summary>
        /// Represents the depth where the soil temperature was measured (in meters).
        /// </summary>
        public double Depth { get; }

        #endregion

        #region Methods

        public override string ToString() {
            return $"Measured in {Place} (depth: {Depth} metre(s)) at {RecordTime}. Temperature: {Temp}C";
        }

        #endregion
    }
}