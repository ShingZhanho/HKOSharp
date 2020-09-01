// Notes: This file will include tests for SeaTemp, SoilTemp, OneDayWeather and WeatherIcon classes

using HKOSharp;
using HKOSharp.LibHKOSharp;
using NUnit.Framework;

namespace NUnitTest {
    // NineDaysWeather
    public class NDWClassTests {
        [Test]
        public void Constructor_NullJSON_Fail() {
            // Arrange
            string nullJson = null;
            
            // Acts
            var ndw = new NineDaysWeather(nullJson, Language.English);
            
            // Asserts
            Assert.IsFalse(ndw.IsSucceeded);
        }
        
        [Test]
        public void Constructor_InvalidJSON_Fail() {
            // Arrange
            const string invalidJson = "This json is invalid.";
            
            // Acts
            var ndw = new NineDaysWeather(invalidJson, Language.English);
            
            // Asserts
            Assert.IsFalse(ndw.IsSucceeded);
        }
        
        [Test]
        public void Constructor_FailToAssignProperties_Fail() {
            // Arrange
            const string wrongJsonFormat = "{\"sample\":\"not correct format\"}";
            
            // Acts
            var ndw = new NineDaysWeather(wrongJsonFormat, Language.English);
            
            // Asserts
            Assert.IsFalse(ndw.IsSucceeded);
        }

        [Test]
        public void ClassToString_AllLanguages_NotNull(
            [Values(Language.English, Language.TraditionalChinese, Language.SimplifiedChinese)] Language language) {
            // Arrange
            var ndw = Weather.GetNineDaysWeather(language);
            
            // Acts
            var ndwString = ndw.ToString();
            
            // Asserts
            Assert.IsNotNull(ndwString);
        }
    }
}