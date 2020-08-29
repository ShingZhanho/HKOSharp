using System;
using HKOSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HKOSharp.LibHKOSharp;

namespace UnitTestProject {
    /*
     * Instructions for naming TestMethods
     * 
     * For testing a public method:
     * [Method Name]_[Parameter(s)]_[Expected Return Value]() or
     * [Method Name]_[Parameter(s)]_T[Expected Exception]()
     *
     * For testing a internal method, use same naming rules, add 'I' before method name.
     * e.g. I[Method Name]_[Parameter(s)_[Expected Return Value]()
     */
    
    [TestClass]
    public class WeatherClassTest {
        
        [TestMethod]
        public void GetLocalWeatherForecast_AllLang_LocalWeatherForecastObjectsWithSuccess() {
            // Acts
            var localWeatherForecast = new[] {
                Weather.GetLocalWeatherForecast(Language.English),
                Weather.GetLocalWeatherForecast(Language.TraditionalChinese),
                Weather.GetLocalWeatherForecast(Language.SimplifiedChinese),
            };
            
            // Asserts
            foreach (var lwf in localWeatherForecast){
                Assert.IsTrue(lwf.IsSucceeded);
                Assert.IsNull(lwf.FailMessage);
            }
        }

        [TestMethod]
        public void GetLocalWeatherForecastAsync_AllLang_LocalWeatherForecastObjectsWithSuccess() {
            // Acts
            var localWeatherForecast = new[] {
                Weather.GetLocalWeatherForecastAsync(Language.English).Result,
                Weather.GetLocalWeatherForecastAsync(Language.TraditionalChinese).Result,
                Weather.GetLocalWeatherForecastAsync(Language.SimplifiedChinese).Result,
            };
            
            // Asserts
            foreach (var lwf in localWeatherForecast){
                Assert.IsTrue(lwf.IsSucceeded);
                Assert.IsNull(lwf.FailMessage);
            }
        }

        [TestMethod]
        public void GetLocalWeatherForecast_InvalidJson_Null() {
            // Arrange
            Weather.UT_InvalidJson = "This is invalid JSON string";
            
            // Acts
            var forecast = Weather.GetLocalWeatherForecast();
            
            // Asserts
            Assert.IsNull(forecast);
        }

        [TestMethod]
        public void GetLocalWeatherForecast_HttpError_Null() {
            // Arrange
            Weather.UT_HttpRequestFail = true;
            
            // Acts
            var forecast = Weather.GetLocalWeatherForecast();
            
            // Asserts
            Assert.IsNull(forecast);
        }
    }
}