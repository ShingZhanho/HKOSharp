using System;

namespace HKOSharp {
    public class CurrentWeatherReport {
        internal CurrentWeatherReport(string json) {
            
        }
    }

    public class Lightnings {
        // Fields
        public string[] Places { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
    }
}