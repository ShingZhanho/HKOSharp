using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    
    
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
        public string Place { get; }
        public double Temperature { get; }
        public DateTime RecordTime { get; }
        public Language Language { get; }
        
        // Fields indicating if deserializing is succeeded
        internal bool IsSucceeded { get; set; }
        internal string FailMessage { get; set; }
        
        // Methods
        private const string ToStringTemplateEng = "Sea temperature {0}C was recorded at {1} in {2}.";
        private const string ToStringTemplateChiT = "在{0}於{1}測得海溫{2}C。";
        private const string ToStringTemplateChiS = "在{0}于{1}测得海温{2}C。";

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
        public string Place { get; }
        public double Temperature { get; }
        public DateTime RecordTime { get; }
        public double Depth { get; }
        public Language Language { get; }
        
        // Methods
        private const string ToStringTemplateEng = "Soil temperature {0}C was recorded at {1} in {2} ({3}m deep).";
        private const string ToStringTemplateChiT = "在{0}於{1}測得地面溫度{2}C（深度{3}米}）。";
        private const string ToStringTemplateChiS = "在{0}于{1}测得地面温度{2}C（深度{3}米}）。";

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