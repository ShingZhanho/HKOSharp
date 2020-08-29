using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    public class LocalWeatherForecast {
        internal LocalWeatherForecast(string json, Language language) {
            Language = language;
            if (json is null) {
                IsSucceeded = false;
                FailMessage = "Cannot instantiate LocalWeatherForecast object. JSON string is null.";
                return;
            }

            JObject jo;
            try {
                jo = (JObject) JsonConvert.DeserializeObject(json);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                IsSucceeded = false;
                FailMessage = "Cannot instantiate LocalWeatherForecast object. JSON deserializing failed.";
                return;
            }
            
            try {
                GeneralSituation = jo["generalSituation"].ToString();
                TCInfo = jo["tcInfo"].ToString();
                FireDangerWarning = jo["fireDangerWarning"].ToString();
                ForecastPeriod = jo["forecastPeriod"].ToString();
                ForecastDesc = jo["forecastDesc"].ToString();
                Outlook = jo["outlook"].ToString();
                UpdateTime = DateTime.Parse(jo["updateTime"].ToString());
                IsSucceeded = true;
            }
            catch (Exception e){
                IsSucceeded = false;
                FailMessage = 
                    $"JSON Deserializing failed. JSON string: {json}. Details:\n    {e.Source}\n    {e.Message}";
                return;
            }

            IsSucceeded = true;
        }

        // Fields
        /// <summary>
        /// Represents the general situation.
        /// </summary>
        public string GeneralSituation { get; }
        /// <summary>
        /// Represents the tropical cyclone information.
        /// </summary>
        public string TCInfo { get; }
        /// <summary>
        /// Represents information about fire danger warning.
        /// </summary>
        public string FireDangerWarning { get; }
        /// <summary>
        /// Represents period of this forecast is for.
        /// </summary>
        public string ForecastPeriod { get; }
        /// <summary>
        /// Represents the description of this forecast.
        /// </summary>
        public string ForecastDesc { get; }
        /// <summary>
        /// Represents the outlook information.
        /// </summary>
        public string Outlook { get; }
        /// <summary>
        /// Represents when this forecast was updated.
        /// </summary>
        public DateTime UpdateTime { get; }
        /// <summary>
        /// Represents which language is this forecast in.
        /// </summary>
        public Language Language { get; }
        
        // Fields indicating if deserialization is succeeded
        /// <summary>
        /// Represents whether the JSON deserializing is successful.
        /// </summary>
        public bool IsSucceeded { get; }
        /// <summary>
        /// Represents the error message if <see cref="IsSucceeded"/> is false.
        /// </summary>
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
        
        private const string ToStringTemplateChiS = "概况: {0}\n" +
                                                    "热带气旋资讯: {1}\n" +
                                                    "火灾危险警告讯息: {2}\n" +
                                                    "预测时段: {3}\n" +
                                                    "预测内容: {4}\n" +
                                                    "展望: {5}\n" +
                                                    "更新时间: {6}";
        
        /// <summary>
        /// Returns a string represents this object. Language of this string depends on language parameter.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public override string ToString() {
            // If failed
            if (!IsSucceeded) 
                return $"This object has no information since it is marked as failed. Message: {FailMessage}";
            
            // If succeeded
            var template = Language switch {
                Language.English => ToStringTemplateEng,
                Language.TraditionalChinese => ToStringTemplateChiT,
                Language.SimplifiedChinese => ToStringTemplateChiS,
                _ => ToStringTemplateEng
            };
            return string.Format(template, GeneralSituation,
                TCInfo, FireDangerWarning, ForecastPeriod, ForecastDesc, Outlook, UpdateTime);
        }
    }
}