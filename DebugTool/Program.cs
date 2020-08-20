using System;
using HKOSharp;

namespace DebugTool {
    internal class Program {
        public static void Main(string[] args) {
            LibHKOSharp.Weather.GetLocalWeatherForecast(Language.English);
            Console.Read();
        }
    }
}