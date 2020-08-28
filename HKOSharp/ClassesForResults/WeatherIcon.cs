using System;
using System.Drawing;
using LibHKOSharp.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HKOSharp {
    /// <summary>
    /// Represents a weather icon
    /// </summary>
    public class WeatherIcon {
        internal WeatherIcon(int iconCode, Language language) {
            IconCode = iconCode;

            var jo = (JObject) JsonConvert.DeserializeObject(Resources.JSON_iconDesc);
            if (jo is null) return;

            IconDesc = jo["iconDescriptions"][$"{iconCode}"][$"{(int) language}"].ToString();

            Icon = (Bitmap) Resources.ResourceManager.GetObject($"icon{IconCode}");
        }
        
        // Fields
        public Bitmap Icon { get; }
        public int IconCode { get; }
        public string IconDesc { get; }
    }
}