using HKOSharp;
using HKOSharp.LibHKOSharp;
using NUnit.Framework;

namespace NUnitTest {
    public class WeatherTests {
        [Test]
        public void GetLocalWeatherForecast_WithLanguages_IsSucceeded(
            [Values(Language.English, Language.TraditionalChinese, Language.SimplifiedChinese)]
            Language language) {
            // Arrange
            Weather.UT_InvalidJson = null;
            Weather.UT_HttpRequestFail = false;

            // Acts
            var lwf = Weather.GetLocalWeatherForecast(language);

            // Asserts
            if (lwf is null) Assert.Fail();

            Assert.IsTrue(lwf.IsSucceeded);
            Assert.IsNull(lwf.FailMessage);
        }

        [Test]
        public void GetLocalWeatherForecastAsync_WithLanguages_IsSucceeded(
            [Values(Language.English, Language.TraditionalChinese, Language.SimplifiedChinese)]
            Language language) {
            // Arrange
            Weather.UT_InvalidJson = null;
            Weather.UT_HttpRequestFail = false;

            // Acts
            var lwfAsync = Weather.GetLocalWeatherForecastAsync(language).Result;

            // Asserts
            Assert.IsTrue(lwfAsync.IsSucceeded);
            Assert.IsNull(lwfAsync.FailMessage);
        }

        [Test]
        public void GetNineDaysWeather_WithLanguages_IsSucceeded(
            [Values(Language.English, Language.TraditionalChinese, Language.SimplifiedChinese)] Language language) {
            // Arrange
            Weather.UT_InvalidJson = null;
            Weather.UT_HttpRequestFail = false;

            // Acts
            var ndw = Weather.GetNineDaysWeather(language);

            // Asserts
            Assert.IsTrue(ndw.IsSucceeded);
            Assert.IsNull(ndw.FailMessage);
        }
        
        [Test]
        public void GetNineDaysWeatherAsync_WithLanguages_IsSucceeded(
            [Values(Language.English, Language.TraditionalChinese, Language.SimplifiedChinese)] Language language) {
            // Arrange
            Weather.UT_InvalidJson = null;
            Weather.UT_HttpRequestFail = false;

            // Acts
            var ndwAsync = Weather.GetNineDaysWeatherAsync(language).Result;

            // Asserts
            Assert.IsTrue(ndwAsync.IsSucceeded);
            Assert.IsNull(ndwAsync.FailMessage);
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