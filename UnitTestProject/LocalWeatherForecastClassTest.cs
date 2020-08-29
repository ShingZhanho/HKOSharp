using HKOSharp;
using HKOSharp.LibHKOSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject {
    [TestClass]
    public class LocalWeatherForecastClassTest {

        [TestMethod]
        public void Constructor_NullJson_Fail() {
            // Arrange
            string nullJson = null;
            
            // Acts
            var lwf = new LocalWeatherForecast(nullJson, Language.English);
            
            // Asserts
            Assert.IsFalse(lwf.IsSucceeded);
        }

        [TestMethod]
        public void Constructor_InvalidJson_Fail() {
            // Arrange
            var invalidJson = "This json is invalid.";
            
            // Acts
            var lwf = new LocalWeatherForecast(invalidJson, Language.English);
            
            // Asserts
            Assert.IsFalse(lwf.IsSucceeded);
        }

        [TestMethod]
        public void Constructor_FailToAssignProperties_Fail() {
            // Arrange
            var wrongJsonFormat = "{\"sample\":\"not correct format\"}";
            
            // Acts
            var lwf = new LocalWeatherForecast(wrongJsonFormat, Language.English);
            
            // Asserts
            Assert.IsFalse(lwf.IsSucceeded);
        }

        [TestMethod]
        public void ClassProperties__NotNull() {
            // Arrange
            var lwf = Weather.GetLocalWeatherForecast();

            // Acts
            var properties = new[] {
                lwf.GeneralSituation,
                lwf.TCInfo,
                lwf.FireDangerWarning,
                lwf.ForecastPeriod,
                lwf.ForecastDesc,
                lwf.Outlook,
                lwf.UpdateTime.ToString(),
                ((int)lwf.Language).ToString()
            };
            
            // Asserts
            foreach (var property in properties) {
                Assert.IsNotNull(properties);
            }
        }

        [TestMethod]
        public void ClassToString__NotNull() {
            // Arrange
            var lwfs = new[] {
                Weather.GetLocalWeatherForecast(), // Test normal local weather forecast object
                new LocalWeatherForecast("invalid JSON", Language.English), // Test a filed object
            };
            
            // Asserts
            foreach (var lwf in lwfs) {
                Assert.IsNotNull(lwf.ToString());
            }
        }
    }
}