using HKOSharp;
using HKOSharp.LibHKOSharp;
using NUnit.Framework;

namespace NUnitTest {
    public class LWFClassTests {
        
        [Test]
        public void Constructor_NullJSON_Fail() {
            // Arrange
            string nullJson = null;
            
            // Acts
            var lwf = new LocalWeatherForecast(nullJson, Language.English);
            
            // Asserts
            Assert.IsFalse(lwf.IsSucceeded);
        }

        [Test]
        public void Constructor_InvalidJSON_Fail() {
            // Arrange
            const string invalidJson = "This json is invalid.";
            
            // Acts
            var lwf = new LocalWeatherForecast(invalidJson, Language.English);
            
            // Asserts
            Assert.IsFalse(lwf.IsSucceeded);
        }
        
        [Test]
        public void Constructor_FailToAssignProperties_Fail() {
            // Arrange
            const string wrongJsonFormat = "{\"sample\":\"not correct format\"}";
            
            // Acts
            var lwf = new LocalWeatherForecast(wrongJsonFormat, Language.English);
            
            // Asserts
            Assert.IsFalse(lwf.IsSucceeded);
        }

        [Test]
        public void ClassToString_AllLanguages_NotNull(
            [Values(Language.English, Language.TraditionalChinese, Language.SimplifiedChinese)] Language language) {
            // Arrange
            var lwf = Weather.GetLocalWeatherForecast(language);
            
            // Acts
            var lwfString = lwf.ToString();
            
            // Asserts
            Assert.IsNotNull(lwfString);
        }
    }
}