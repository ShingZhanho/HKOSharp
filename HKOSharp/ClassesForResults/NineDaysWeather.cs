using System;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    
    
    public class SeaTemp {
        protected SeaTemp(){}

        internal SeaTemp(JObject jObject) {
            
        }
        
        // Fields
        public string Place { get; private set; }
        public double Temperature { get; private set; }
        public DateTime RecordTime { get; private set; }
    }

    public class SoilTemp : SeaTemp {
        internal SoilTemp(string json) {
            
        }
        
        // Fields
        public double Depth { get; private set; }
    }
}