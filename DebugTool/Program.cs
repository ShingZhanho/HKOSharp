using System;
using HKOSharp;

namespace DebugTool {
    internal class Program {
        public static void Main(string[] args) {
                MainMenu();
        }

        private static void MainMenu() {
            while (true) {
                Console.Clear();

                // Shows the main menu
                Console.WriteLine("This a tool for testing LibHKOSharp.\n" +
                                  "Current location: [MAIN MENU]\n");
                Console.WriteLine("[ 1 ]  Get Weather Info");
                Console.WriteLine("[ 2 ]  Get Earthquake Info");
                Console.WriteLine("[ 3 ]  Get Climate and Weather Info");
                Console.WriteLine("[ # ]  Exits the tool");
                Console.Write("\nEnter an option to perform operation: ");

                switch (Console.ReadLine()) {
                    case "1":
                        MenuOne();
                        return;
                    case "2":
                        MenuTwo();
                        return;
                    case "#":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void MenuOne() {
            while (true) {
                Console.Clear();

                // Shows menu one
                Console.WriteLine("You are in menu [WEATHER INFO].\n" +
                                  "Current location: [MAIN MENU] > [WEATHER INFO]\n");
                Console.WriteLine("[ 1 ]  Get Local Weather Forecast");
                Console.WriteLine("[ 2 ]  Get Nine Days Weather Forecast");
                Console.WriteLine("[ 3 ]  Get Current Weather Report");
                Console.WriteLine("[ 4 ]  Get Weather Warning Info");
                Console.WriteLine("[ 5 ]  Get Weather Warning Summary");
                Console.WriteLine("[ 6 ]  Get Special Weather Tips");
                Console.WriteLine("\n[ # ]  Return to upper menu");
                Console.Write("Enter an option to perform operation: ");
                var option = Console.ReadLine();

                if (option == "1") {
                    Console.Clear();
                    
                    Console.WriteLine("Testing Weather.GetLocalWeatherForecast()");
                    Console.WriteLine(LibHKOSharp.Weather.GetLocalWeatherForecast(Language.English).ToString());
                    
                    Console.WriteLine("Testing Weather.GetLocalWeatherForecastAsync()");
                    Console.WriteLine(LibHKOSharp.Weather.GetLocalWeatherForecastAsync(Language.English).ToString());
                    Console.Read();
                    continue;
                }
                if (option == "#") {
                    MainMenu();
                    return;
                }
            }
        }

        private static void MenuTwo() {
            while (true) {
                Console.Clear();
                
                // Shows menu two
                Console.WriteLine("You are in menu [EARTHQUAKE INFO].\n" +
                                  "Current location: [MAIN MENU] > [EARTHQUAKE INFO]\n");
                Console.WriteLine("[ 1 ]  Get Quick Earthquake Messages");
                Console.WriteLine("[ 2 ]  Get Local Felt Earth Tremor Report");
                Console.WriteLine("[ # ]  Return to upper menu");
                Console.Write("\nEnter an option to perform operation: ");
                var option = Console.ReadLine();
                
                if (option == "#") {
                    MainMenu();
                    return;
                }
            }
        }
    }
}