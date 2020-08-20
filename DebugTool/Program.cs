using System;
using HKOSharp;

namespace DebugTool {
    internal class Program {
        public static void Main(string[] args) {
            var localWeatherForecast = LibHKOSharp.Weather.GetLocalWeatherForecast(Language.TraditionChinese);
            Console.WriteLine("概況：{0}", localWeatherForecast.GeneralSituation);
            Console.Read();
        }
    }
}