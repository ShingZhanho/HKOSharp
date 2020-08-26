using System;
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
            Console.WriteLine(result.ToString());
            Assert.IsTrue(result.IsSucceeded, result.FailMessage);
        }

        [TestMethod]
        public void GetLocalWeatherForecastAsync_WithNoEnum_LocalWeatherForecastObject() {
            //acts
            var result = Weather.GetLocalWeatherForecastAsync().Result;

            //asserts
            Console.WriteLine(result.ToString());
            Assert.IsTrue(result.IsSucceeded, result.FailMessage);
        }
    }
}