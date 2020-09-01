using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    /// <summary>
    /// Contains all information about future nine days' weather forecast
    /// </summary>
    public class NineDaysWeather {
        internal NineDaysWeather(string json, Language language) {
            if (json is null) {
                IsSucceeded = false;
                FailMessage = "Cannot instantiate NineDaysWeather object. JSON string is null.";
                return;
            }

            var jo = (JObject) JsonConvert.DeserializeObject(json);
            if (jo is null) {
                IsSucceeded = false;
                FailMessage = $"Cannot instantiate NineDaysWeather object. JSON string is invalid.";
                return;
            }
            
            Language = language;
            WeatherForecast = new List<OneDayWeather>();
            SoilTemps = new List<SoilTemp>();

            try {
                GeneralSituation = jo["generalSituation"].ToString();
                UpdateTime = DateTime.Parse(jo["updateTime"].ToString());
            }
            catch (Exception e) {
                IsSucceeded = false;
                FailMessage = 
                    $"JSON Deserializing failed. Details:\n    {e.Source}\n    {e.Message}";
                return;
            }

            // Assign OneDayWeather objects to WeatherForecast
            for (var i = 0; i < 9; i++) { // There will be nine weather forecasts in json
                var weather = new OneDayWeather(jo["weatherForecast"][i].ToString(), language);
                if (!weather.IsSucceeded) { // If weather object is failed to initiate
                    IsSucceeded = false;
                    FailMessage =
                        "Deserialization failed. Error was caused by OneDayWeather object. " +
                        $"Message: {weather.FailMessage}";
                    return;
                }
                WeatherForecast.Add(weather);
            }
            
            // Assign SeaTemp
            SeaTemp = new SeaTemp(jo, language);
            if (!SeaTemp.IsSucceeded) {
                IsSucceeded = false;
                FailMessage =
                    "Deserialization failed. Error was caused by SeaTemp object. " +
                    $"Message: {SeaTemp.FailMessage}";
                return;
            }
            
            // Add SoilTemp objects to SoilTemps field
            // Extract soilTemp token as independent json string
            // Remove all line breaks before processing
            var jsonSoilTemp = jo["soilTemp"]?.ToString().Replace("\r\n","");
            // Remove unnecessary white-spaces
            foreach (var match in Regex.Matches(jsonSoilTemp, @"\s{2,}|:\s{1,}"))
                jsonSoilTemp = match.ToString().Contains(":")
                    ? jsonSoilTemp.Replace(": ", ":")
                    : jsonSoilTemp.Replace(match.ToString(), "");
            foreach (var match in Regex.Matches(jsonSoilTemp, @"\{.*?\}\}")) {
                var item = new SoilTemp(match.ToString(), language);
                if (!item.IsSucceeded) { // If SoilTemp object is failed to deserialize
                    IsSucceeded = false;
                    FailMessage =
                        "Deserialization failed. Error was caused by SoilTemp object. " +
                        $"Message: {item.FailMessage}";
                    return;
                }
                SoilTemps.Add(item);
            }
            
            IsSucceeded = true;
        }
        
        // Fields
        /// <summary>
        /// A string of general situation.
        /// </summary>
        public string GeneralSituation { get; }
        /// <summary>
        /// A list of OneDayWeather objects. Contains future 9 days' weather forecasts.
        /// </summary>
        public List<OneDayWeather> WeatherForecast { get; }
        /// <summary>
        /// Represents the time of this forecast was updated.
        /// </summary>
        public DateTime UpdateTime { get; }
        /// <summary>
        /// A SeaTemp object. Contains information about sea temperature.
        /// </summary>
        public SeaTemp SeaTemp { get; }
        /// <summary>
        /// A list of SoilTemp object. Contains information of soil temperature from different station.
        /// </summary>
        public List<SoilTemp> SoilTemps { get; }
        /// <summary>
        /// Represents the language of these weather forecasts.
        /// </summary>
        public Language Language { get; }
        
        // Fields indicating if JSON deserializing is succeeded
        public bool IsSucceeded { get; }
        public string FailMessage { get; }
        
        // Methods
        private const string ToStringTemplateEng = "General Situation: {0}\n" +
                                                   "Weather forecast of future nine days:\n\n" +
                                                   "{1}\n\n" +
                                                   "{2}\n{3}\n" + // {2} -> SeaTemp, {3} -> SoilTemp
                                                   "Updated: {4}";
        
        private const string ToStringTemplateChiT = "槪況: {0}\n" +
                                                   "未來九天天氣:\n\n" +
                                                   "{1}\n\n" +
                                                   "{2}\n{3}\n" + // {2} -> SeaTemp, {3} -> SoilTemp
                                                   "更新時間: {4}";
        
        private const string ToStringTemplateChiS = "概况: {0}\n" +
                                                    "未来九天天气:\n\n" +
                                                    "{1}\n\n" +
                                                    "{2}\n{3}\n" + // {2} -> SeaTemp, {3} -> SoilTemp
                                                    "更新时间: {4}";

        /// <summary>
        /// Returns a string which contains all information in this object.
        /// </summary>
        public override string ToString() {
            // If failed
            if (!IsSucceeded)
                return $"This NineDaysWeather object has no information because it is marked as failed. Message: {FailMessage}";
            
            var nineDaysWeather = "";
            foreach (var day in WeatherForecast) {
                nineDaysWeather += day + "\n\n";
            }

            var soilTemps = "";
            foreach (var temp in SoilTemps) {
                soilTemps += temp + "\n";
            }

            return Language switch {
                Language.English => string.Format(ToStringTemplateEng, GeneralSituation, nineDaysWeather
                ,SeaTemp, SeaTemp, UpdateTime),
                Language.TraditionalChinese => string.Format(ToStringTemplateChiT, GeneralSituation, nineDaysWeather
                    ,SeaTemp, SeaTemp, UpdateTime),
                Language.SimplifiedChinese => string.Format(ToStringTemplateChiS, GeneralSituation, nineDaysWeather
                    ,SeaTemp, SeaTemp, UpdateTime)
            };
        }
    }

    /// <summary>
    /// Contains all information about a specific day's weather forecast
    /// </summary>
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
                FailMessage = $"Cannot instantiate OneDayWeather object. JSON string is invalid.";
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

                // TODO: REMOVE THIS IN VERSION 1.0
                ForecastIcon = Convert.ToInt32(jo["ForecastIcon"].ToString()); // Deprecated, to be removed in version 1.0

                WeatherIcon = new WeatherIcon(Convert.ToInt32(jo["ForecastIcon"].ToString()),
                    language);
                if (WeatherIcon.Icon is null) {
                    IsSucceeded = false;
                    FailMessage = "JSON Deserializing failed. Error was caused by WeatherIcon object";
                    return;
                }

                var dateString = jo["forecastDate"].ToString(); // format: yyyyMMdd
                ForecastDate = new DateTime(
                    int.Parse(dateString.Substring(0, 4)),
                    int.Parse(dateString.Substring(4, 2)),
                    int.Parse(dateString.Substring(6)));
            } catch (Exception e) {
                IsSucceeded = false;
                FailMessage =
                    $"JSON Deserializing failed. Details:\n    {e.Source}\n    {e.Message}";
                return;
            }

            IsSucceeded = true;
        }

        // Fields
        /// <summary>
        /// Represents the date of this forecast.
        /// </summary>
        public DateTime ForecastDate { get; }

        /// <summary>
        /// A string which represents the day of a week: Monday, Saturday etc.
        /// Language depends on the language parameter.
        /// </summary>
        public string Week { get; }

        /// <summary>
        /// A string which describes the wind of that day.
        /// </summary>
        public string ForecastWind { get; }

        /// <summary>
        /// A string which describes the weather of that day.
        /// </summary>
        public string ForecastWeather { get; }

        /// <summary>
        /// Represents the maximum temperature of that day (in degrees Celsius).
        /// </summary>
        public double ForecastMaxTemp { get; }

        /// <summary>
        /// Represents the minimum temperature of that day (in degrees Celsius).
        /// </summary>
        public double ForecastMinTemp { get; }

        /// <summary>
        /// Represents the highest relative humidity of that day (in percent).
        /// </summary>
        public double ForecastMaxRh { get; }

        /// <summary>
        /// Represents the lowest relative humidity of that day (in percent).
        /// </summary>
        public double ForecastMinRh { get; }

        /// <summary>
        /// Represents number of the forecast icon of that day.
        /// Check the list of forecast icons <see cref="https://www.hko.gov.hk/textonly/v2/explain/wxicon_c.htm">here</see>.
        /// </summary>
        [Obsolete("This field is obsolete. Use WeatherIcon field instead.")]
        public int ForecastIcon { get; }
        /// <summary>
        /// Represents a forecast icon.
        /// Check the list of forecast icons <see cref="https://www.hko.gov.hk/textonly/v2/explain/wxicon_c.htm">here</see>.
        /// </summary>
        public WeatherIcon WeatherIcon { get; }
    

    private Language Language;
        
        // Fields indicating whether JSON deserializing is succeeded
        internal bool IsSucceeded { get; }
        internal string FailMessage { get; }
        
        // Methods
        private const string ToStringTemplateEng = "Weather forecast for {0}, {1}:\n" +
                                                   "Weather: {2}\n" +
                                                   "Wind: {3}\n" +
                                                   "Temperature: {4}C - {5}C\n" +
                                                   "Relative Humidity: {6}% - {7}%\n" +
                                                   "Forecast Icon Code: {8}";
        
        private const string ToStringTemplateChiT = "以下為 {0}, {1} 的天氣預測:\n" +
                                                   "天氣槪況: {2}\n" +
                                                   "風力: {3}\n" +
                                                   "溫度: {4}C 至 {5}C\n" +
                                                   "相對濕度: {6}% 至 {7}%\n" +
                                                   "天氣圖示編號: {8}";
        
        private const string ToStringTemplateChiS = "以下是 {0}, {1} 的天气预测:\n" +
                                                    "天气概况: {2}\n" +
                                                    "风力: {3}\n" +
                                                    "温度: {4}C 至 {5}C\n" +
                                                    "相对湿度: {6}% 至 {7}%\n" +
                                                    "天气标志编号: {8}";

        public override string ToString() {
            // If failed
            if (!IsSucceeded)
                return $"This OneDayWeather object has no information since it is marked as failed. Message: {FailMessage}";
            
            // If succeeded
            return Language switch {
                Language.English => string.Format(ToStringTemplateEng, ForecastDate, Week, ForecastWeather,
                    ForecastWind, ForecastMinTemp, ForecastMaxTemp, ForecastMinRh, ForecastMaxRh, WeatherIcon.IconCode),
                Language.TraditionalChinese => string.Format(ToStringTemplateChiT, ForecastDate, Week, ForecastWeather,
                    ForecastWind, ForecastMinTemp, ForecastMaxTemp, ForecastMinRh, ForecastMaxRh, WeatherIcon.IconCode),
                Language.SimplifiedChinese => string.Format(ToStringTemplateChiS, ForecastDate, Week, ForecastWeather,
                    ForecastWind, ForecastMinTemp, ForecastMaxTemp, ForecastMinRh, ForecastMaxRh, WeatherIcon.IconCode),
            };
        }
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
                Place = jObject["seaTemp"]["place"].ToString();
                Temperature = Convert.ToDouble(jObject["seaTemp"]["value"].ToString());
                RecordTime = DateTime.Parse(jObject["seaTemp"]["recordTime"].ToString());
            }
            catch (Exception e) {
                IsSucceeded = false;
                FailMessage = 
                    $"JSON Deserializing failed. Details:\n    {e.Source}\n    {e.Message}";
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
                return $"This SeaTemp object has no information since it is marked as failed. Message: {FailMessage}";
            
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
                    $"JSON Deserializing failed. Details:\n    {e.Source}\n    {e.Message}";
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
        private const string ToStringTemplateChiT = "在{0}於{1}測得地面溫度{2}C（深度{3}米）。";
        private const string ToStringTemplateChiS = "在{0}于{1}测得地面温度{2}C（深度{3}米）。";

        /// <summary>
        /// Returns a string which contains all the information in this object, language of string depends on language parameter.
        /// </summary>
        public override string ToString() {
            // If failed
            if (!IsSucceeded)
                return $"This SoilTemp object has no information since it is marked as failed. Message: {FailMessage}";
            
            // If succeeded
            return Language switch {
                Language.English => string.Format(
                    ToStringTemplateEng, Temperature.ToString(), RecordTime.ToString(), Place, Depth.ToString()),
                Language.TraditionalChinese => string.Format(
                    ToStringTemplateChiT, Place, RecordTime.ToString(), Temperature.ToString(), Depth.ToString()),
                Language.SimplifiedChinese => string.Format(
                    ToStringTemplateChiS, Place, RecordTime.ToString(), Temperature.ToString(), Depth.ToString())
            };
        }
    }
}