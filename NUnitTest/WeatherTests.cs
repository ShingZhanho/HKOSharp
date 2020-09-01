using HKOSharp;
using HKOSharp.LibHKOSharp;
using NUnit.Framework;

namespace NUnitTest {
    public class WeatherTests {

        [Test]
        public void GetLocalWeatherForecast_WithLanguages_IsSucceeded(
            [Values(Language.English, Language.TraditionalChinese, Language.SimplifiedChinese)] Language language) {
            // Acts
            var lwf = Weather.GetLocalWeatherForecast(language);
            
            // Asserts
            Assert.IsTrue(lwf.IsSucceeded);
            Assert.IsNull(lwf.FailMessage);
        }

        [Test]
        public void GetLocalWeatherForecastAsync_WithLanguages_IsSucceeded(
            [Values(Language.English, Language.TraditionalChinese, Language.SimplifiedChinese)] Language language) {
            // Acts
            var lwfAsync = Weather.GetLocalWeatherForecastAsync(language).Result;
            
            // Asserts
            Assert.IsTrue(lwfAsync.IsSucceeded);
            Assert.IsNull(lwfAsync.FailMessage);
        }

        [Test]
        public void GetLocalWeatherForecast_InvalidJSON_Null() {
            // Arrange
            Weather.UT_InvalidJson = "Invalid JSON";
            
            // Acts
            var lwfNull = Weather.GetLocalWeatherForecast();
            
            // Asserts
            Assert.IsNull(lwfNull);
        }
        
        [Test]
        public void GetLocalWeatherForecastAsync_InvalidJSON_Null() {
            // Arrange
            Weather.UT_InvalidJson = "Invalid JSON";
            
            // Acts
            var lwfNull = Weather.GetLocalWeatherForecastAsync().Result;
            
            // Asserts
            Assert.IsNull(lwfNull);
        }
        
        [Test]
        public void IHttpRequest_HttpError_Null() {
            // Arrange
            Weather.UT_HttpRequestFail = true;
            
            // Acts
            var forecast = Weather.GetLocalWeatherForecast();
            
            // Asserts
            Assert.IsNull(forecast);
        }
        
        [Test]
        public void IHttpRequestAsync_Error_Null() {
            // Arrange
            Weather.UT_HttpRequestFail = true;
            
            // Acts
            var forecast = Weather.GetLocalWeatherForecastAsync().Result;
            
            // Asserts
            Assert.IsNull(forecast);
        }
    }
}