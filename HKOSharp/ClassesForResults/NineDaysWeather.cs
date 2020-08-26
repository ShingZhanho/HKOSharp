using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HKOSharp {

    public class OneDayWeather {
        internal OneDayWeather(string json, Language language) {
            Language = language;
            if (json is null) {
                IsSucceeded = false;
                FailMessage = "Cannot instantiate OneDayWeather object. JSON string is null.";
                return;
            }

            var jo = (JObject) JsonConvert.DeserializeObject(json);
            if (jo is null) {
                IsSucceeded = false;
                FailMessage = $"Cannot instantiate OneDayWeather object. JSON string is invalid. JSON string: {json}";
                return;
            }

            try {
                Week = jo["week"].ToString();
                ForecastWind = jo["forecastWind"].ToString();
                ForecastWeather = jo["forecastWeather"].ToString();
                
                ForecastMaxTemp = Convert.ToDouble(jo["forecastMaxtemp"]["value"].ToString());
                ForecastMinTemp = Convert.ToDouble(jo["forecastMintemp"]["value"].ToString());
                ForecastMaxRh = Convert.ToDouble(jo["forecastMaxrh"]["value"].ToString());
                ForecastMinRh = Convert.ToDouble(jo["forecastMinrh"]["value"].ToString());
                ForecastIcon = Convert.ToInt32(jo["ForecastIcon"].ToString());

                var dateString = jo["forecastDate"].ToString(); // format: yyyyMMdd
                ForecastDate = new DateTime(
                    int.Parse(dateString.Substring(0,4)),
                    int.Parse(dateString.Substring(4, 2)),
                    int.Parse(dateString.Substring(6)));
            }
            catch (Exception e) {
                IsSucceeded = false;
                FailMessage = 
                    $"JSON Deserializing failed. JSON string: {json}. Details:\n    {e.Source}\n    {e.Message}";
                return;
            }

            IsSucceeded = true;
        }
        
        // Fields
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
        private Language Language;
        
        // Fields indicating whether JSON deserializing is succeeded
        internal bool IsSucceeded { get; }
        internal string FailMessage { get; }
    }
    
    /// <summary>
    /// Contains information about sea temperature.
    /// </summary>
    public class SeaTemp {
        protected SeaTemp(){}

        internal SeaTemp(JObject jObject, Language language) {
            Language = language;
            if (jObject is null) {
                IsSucceeded = false;
                FailMessage = "Cannot instantiate SeaTemp object. JObject is null.";
                return;
            }

            try {
                Place = jObject["place"].ToString();
                Temperature = Convert.ToDouble(jObject["value"].ToString());
                RecordTime = DateTime.Parse(jObject["recordTime"].ToString());
            }
            catch (Exception e) {
                IsSucceeded = false;
                FailMessage = 
                    $"JSON Deserializing failed. JSON string: {jObject}. Details:\n    {e.Source}\n    {e.Message}";
                return;
            }

            IsSucceeded = true;
        }
        
        // Fields
        /// <summary>
        /// Represents where the sea temperature was recorded.
        /// </summary>
        public string Place { get; }
        /// <summary>
        /// Represents the recorded sea temperature (in degrees Celsius).
        /// </summary>
        public double Temperature { get; }
        /// <summary>
        /// Represents when the sea temperature was recorded.
        /// </summary>
        public DateTime RecordTime { get; }
        private Language Language { get; }
        
        // Fields indicating if deserializing is succeeded
        internal bool IsSucceeded { get; set; }
        internal string FailMessage { get; set; }
        
        // Methods
        private const string ToStringTemplateEng = "Sea temperature {0}C was recorded at {1} in {2}.";
        private const string ToStringTemplateChiT = "在{0}於{1}測得海溫{2}C。";
        private const string ToStringTemplateChiS = "在{0}于{1}测得海温{2}C。";

        /// <summary>
        /// Returns a string which contains all information in this object. Language depends on language parameter.
        /// </summary>
        public override string ToString() {
            // If failed
            if (!IsSucceeded) 
                return $"This object has no information since it is marked as failed. Message: {FailMessage}";
            
            // If succeeded
            return Language switch {
                Language.English => string.Format(ToStringTemplateEng, Temperature, RecordTime, Place),
                Language.TraditionalChinese => string.Format(ToStringTemplateChiT, RecordTime, Place, Temperature),
                Language.SimplifiedChinese => string.Format(ToStringTemplateChiS, RecordTime, Place, Temperature)
            };
        }
    }

    public class SoilTemp : SeaTemp {
        internal SoilTemp(string json, Language language) {
            Language = language;
            var jo = (JObject) JsonConvert.DeserializeObject(json);
            if (jo is null) {
                IsSucceeded = false;
                FailMessage = "Cannot instantiate SoilTemp object. JSON string is null.";
                return;
            }

            try {
                Place = jo["place"].ToString();
                Temperature = Convert.ToDouble(jo["value"].ToString());
                RecordTime = DateTime.Parse(jo["recordTime"].ToString());
                Depth = Convert.ToDouble(jo["depth"]["value"].ToString());
            }
            catch (Exception e){
                IsSucceeded = false;
                FailMessage = 
                    $"JSON Deserializing failed. JSON string: {json}. Details:\n    {e.Source}\n    {e.Message}";
            }

            IsSucceeded = true;
        }
        
        // Fields
        /// <summary>
        /// Represents where the soil temperature was recorded.
        /// </summary>
        new public string Place { get; }
        /// <summary>
        /// Represents the soil temperature (in degrees Celsius).
        /// </summary>
        new public double Temperature { get; }
        /// <summary>
        /// Represents when the soil temperature was recorded.
        /// </summary>
        new public DateTime RecordTime { get; }
        /// <summary>
        /// Represents how deep the soil temperature was recorded.
        /// </summary>
        public double Depth { get; }
        private Language Language { get; }
        
        // Methods
        private const string ToStringTemplateEng = "Soil temperature {0}C was recorded at {1} in {2} ({3}m deep).";
        private const string ToStringTemplateChiT = "在{0}於{1}測得地面溫度{2}C（深度{3}米}）。";
        private const string ToStringTemplateChiS = "在{0}于{1}测得地面温度{2}C（深度{3}米}）。";

        /// <summary>
        /// Returns a string which contains all the information in this object, language of string depends on language parameter.
        /// </summary>
        public override string ToString() {
            // If failed
            if (!IsSucceeded)
                return $"This object has no information since it is marked as failed. Message: {FailMessage}";
            
            // If succeeded
            return Language switch {
                Language.English => string.Format(ToStringTemplateEng, Temperature, RecordTime, Place, Depth),
                Language.TraditionalChinese => string.Format(ToStringTemplateChiT, RecordTime, Place, Temperature, Depth),
                Language.SimplifiedChinese => string.Format(ToStringTemplateChiS, RecordTime, Place, Temperature, Depth)
            };
        }
    }
}