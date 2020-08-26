using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    public class LocalWeatherForecast {
        internal LocalWeatherForecast(string json, Language language) {
            Language = language;
            var jo = (JObject) JsonConvert.DeserializeObject(json);
            if (jo is null) {
                IsSucceeded = false;
                return;
            }

            try {
                GeneralSituation = jo["generalSituation"].ToString();
                TCInfo = jo["tcInfo"].ToString();
                FireDangerWarning = jo["fireDangerWarning"].ToString();
                ForecastPeriod = jo["forecastPeriod"].ToString();
                ForecastDesc = jo["forecastDecs"].ToString();
                Outlook = jo["outlook"].ToString();
                UpdateTime = DateTime.Parse(jo["updateTime"].ToString());
                IsSucceeded = true;
            }
            catch (Exception e){
                IsSucceeded = false;
                FailMessage = $"JSON Deserializing failed. JSON string: {json}. Details: {e.Source}";
            }

            IsSucceeded = true;
        }
        
        // Fields
        public string GeneralSituation { get; }
        public string TCInfo { get; }
        public string FireDangerWarning { get; }
        public string ForecastPeriod { get; }
        public string ForecastDesc { get; }
        public string Outlook { get; }
        public DateTime UpdateTime { get; }
        public Language Language { get; }
        
        // Fields indicating if deserialization is succeeded
        public bool IsSucceeded { get; }
        public string FailMessage { get; }
        
        // Methods
        private const string ToStringTemplateEng = "General Situation: {0}\n" +
                                                    "Tropical Cyclone Information: {1}\n" +
                                                    "Fire Danger Warning: {2}\n" +
                                                    "Forecast Period: {3}\n" +
                                                    "Forecast Description: {4}\n" +
                                                    "Outlook: {5}\n" +
                                                    "Update Time: {6}";

        private const string ToStringTemplateChiT = "槪況: {0}\n" +
                                                   "熱帶氣訊資訊: {1}\n" +
                                                   "火災危險警告訊息: {2}\n" +
                                                   "預測時段: {3}\n" +
                                                   "預測內容: {4}\n" +
                                                   "展望: {5}\n" +
                                                   "更新時間: {6}";
        
        /// <summary>
        /// Returns a string represents this object.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public override string ToString() {
            var template = Language switch {
                Language.English => ToStringTemplateEng,
                Language.TraditionalChinese => ToStringTemplateChiT,
            };
            return string.Format(template, GeneralSituation,
                TCInfo, FireDangerWarning, ForecastPeriod, ForecastDesc, Outlook, UpdateTime);
        }
    }
}