using HKOSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HKOSharp.LibHKOSharp;

namespace UnitTestProject {
    [TestClass]
    public class UnitTest_WeatherClass {
        [TestMethod]
        public void GetLocalWeatherForecast_WithNoEnum_LocalWeatherForecastObject() {
            //acts
            var result = Weather.GetLocalWeatherForecast();
            
            //asserts
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLocalWeatherForecastAsync_WithNoEnum_LocalWeatherForecastObject() {
            //acts
            var result = Weather.GetLocalWeatherForecastAsync().Result;

            //asserts
            Assert.IsNotNull(result);
        }
    }
}