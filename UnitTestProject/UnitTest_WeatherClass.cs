using System;
using HKOSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HKOSharp.LibHKOSharp;

namespace UnitTestProject {
    [TestClass]
    public class UnitTest_WeatherClass {
        [TestMethod]
        public void GetLocalWeatherForecast_WithAllLanguages_LocalWeatherForecastObject() {
            //acts
            var results = new[] {
                Weather.GetLocalWeatherForecast(),
                Weather.GetLocalWeatherForecast(Language.TraditionalChinese),
                Weather.GetLocalWeatherForecast(Language.SimplifiedChinese)
            };
            
            //asserts
            foreach (var item in results) {
                Console.WriteLine(item.ToString());
                Assert.IsTrue(item.IsSucceeded);
            }
        }

        [TestMethod]
        public void GetLocalWeatherForecastAsync_WithAllLanguages_LocalWeatherForecastObject() {
            //acts
            var results = new[] {
                Weather.GetLocalWeatherForecastAsync().Result,
                Weather.GetLocalWeatherForecastAsync(Language.TraditionalChinese).Result,
                Weather.GetLocalWeatherForecastAsync(Language.SimplifiedChinese).Result
            };

            //asserts
            foreach (var item in results) {
                Console.WriteLine(item.ToString());
                Assert.IsTrue(item.IsSucceeded);
            }
        }

        [TestMethod]
        public void GetNineDaysWeather_WithAllLanguages_NineDaysWeatherObject() {
            //acts
            var results = new[] {
                Weather.GetNineDaysWeather(),
                Weather.GetNineDaysWeather(Language.TraditionalChinese),
                Weather.GetNineDaysWeather(Language.SimplifiedChinese)
            };
            
            //asserts
            foreach (var item in results) {
                Console.WriteLine(item.ToString());
                Assert.IsTrue(item.IsSucceeded);
            }
        }
        
        [TestMethod]
        public void GetNineDaysWeatherAsync_WithAllLanguages_NineDaysWeatherObject() {
            //acts
            var results = new[] {
                Weather.GetNineDaysWeatherAsync().Result,
                Weather.GetNineDaysWeatherAsync(Language.TraditionalChinese).Result,
                Weather.GetNineDaysWeatherAsync(Language.SimplifiedChinese).Result
            };
            
            //asserts
            foreach (var item in results) {
                Console.WriteLine(item.ToString());
                Assert.IsTrue(item.IsSucceeded);
            }
        }
    }
}