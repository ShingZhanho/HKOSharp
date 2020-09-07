# Get started

Follow these steps to use HKOSharp in your code:

## Install HKOSharp

Select one of the following methods to install HKOSharp.

<!-- tabs:start -->

#### ** NuGet Package Manager **

Run the following command in your Package Manager console:

```bash
Install-Package HKOSharp
```

#### ** .NET CLI **

Run the following command in terminal:

```bash
dotnet add package HKOSharp
```

#### ** PackageReference **

Add this line in your `.csproj` file, replace "version-you-want" to an available version name.

```xml
<PackageReference Include="HKOSharp" Version="version-you-want" />
```

<!-- tabs:end -->



## Add reference in your code

Add the following lines before all namespaces, classes and functions:

```c#
using HKOSharp;				// HKOSharp contains all types for receiving results.
using HKOSharp.LibHKOSharp; // LibHKOSharp contains all methods for getting information.
```



## Writing your first code with HKOSharp

```c#
var ndw = Weather.GetNineDaysWeatherAsync(Language.English).Result;
Console.Writeline("Tomorrow's highest temperature will be {0}, and lowest will be {1}.",
                  ndw.WeatherForecast[0].ForecastMaxtemp,
                  ndw.WeatherForecast[0].ForecastMintemp);
```

Run the code and check results or check the docs for more usages.