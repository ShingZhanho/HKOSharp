using System.Drawing;
using System.IO;
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

            IconDesc = jo["iconDescriptions"][$"{iconCode}"][(int) language].ToString();

            var imgBytes = (byte[]) Resources.ResourceManager.GetObject($"icon{IconCode}");
            if (imgBytes is null) return;

            using var stream = new MemoryStream(imgBytes);
            Icon = (Bitmap) Image.FromStream(stream);
        }
        
        // Fields
        public Bitmap Icon { get; }
        public int IconCode { get; }
        public string IconDesc { get; }
    }
}