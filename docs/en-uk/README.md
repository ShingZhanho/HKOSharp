# Introduction

<img src="https://github.com/ShingZhanho/HKOSharp/workflows/Build/badge.svg" alt="Build Status"> <a href="https://codecov.io/gh/ShingZhanho/HKOSharp"><img src="https://codecov.io/gh/ShingZhanho/HKOSharp/branch/master/graph/badge.svg" alt="codecov"></a> <img src="https://img.shields.io/nuget/v/HKOSharp?color=blue&amp;label=nuget" alt="Nuget version"> <img src="https://img.shields.io/github/v/release/ShingZhanho/HKOSharp?include_prereleases&amp;label=latest%20release" alt="GitHub latest version"> <img src="https://img.shields.io/github/license/ShingZhanho/HKOSharp" alt="License"> <a href="https://github.com/ShingZhanho/HKOSharp/stargazers"><img alt="GitHub stars" src="https://img.shields.io/github/stars/ShingZhanho/HKOSharp?color=yellow"></a>


## What is HKOSharp?

"HKO" stands for Hong Kong Observatory, and "Sharp" means C#. Which means, HKOSharp is a C# library for accessing Hong Kong Observatory's API. Here shows an example getting tomorrows temperature:

```c#
using HKOSharp;
using HKOSharp.LibHKOSharp;

var ndw = Weather.GetNineDaysWeatherAsync(Language.English).Result;
Console.Writeline("Tomorrow's highest temperature will be {0}, and lowest will be {1}.",
                  ndw.WeatherForecast[0].ForecastMaxtemp,
                  ndw.WeatherForecast[0].ForecastMintemp);

// Output:
// Tomorrow's highest temperature will be 34, and lowest will be 28.
```

## Why HKOSharp?

HKOSharp does all HTTP requests and JSON stuffs for you, so you don't need to write a bunch of complicated things in your own code and improve readability.

## Give it a shot!

Follow instructions and see examples in [this page](en-uk/get-started). Or check API references by selecting a Class from the sidebar.