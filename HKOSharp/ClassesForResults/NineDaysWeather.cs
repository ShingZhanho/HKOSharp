using System;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    
    
    public class SeaTemp {
        protected SeaTemp(){}

        internal SeaTemp(JObject jObject, Language language) {
            Language = language;
        }
        
        // Fields
        public string Place { get; protected set; }
        public double Temperature { get; protected set; }
        public DateTime RecordTime { get; protected set; }
        public Language Language { get; protected set; }
        
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
        }
        
        // Fields
        public double Depth { get; private set; }
        
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