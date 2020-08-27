<p align="center">
<img src="ReadmeImages/HKOSharp_Logo.png" height=200/><br>
<strong>LibHKOSharp</strong><br>
An unofficial C# Library of Hong Kong Observatory Open Data API
</p>

---

![Build status](https://circleci.com/gh/ShingZhanho/HKOSharp.svg?style=shield)
[![codecov](https://codecov.io/gh/ShingZhanho/HKOSharp/branch/master/graph/badge.svg)](https://codecov.io/gh/ShingZhanho/HKOSharp)

![Nuget version](https://img.shields.io/nuget/v/HKOSharp?color=blue&label=nuget)
![GitHub latest version](https://img.shields.io/github/v/release/ShingZhanho/HKOSharp?include_prereleases&label=latest%20release)

![License](https://img.shields.io/github/license/ShingZhanho/HKOSharp)


# What is HKOSharp?

HKOSharp is a C# library which allows you to access the Hong Kong Observatory Open Data API without handling bunches of Http requests, responses or JSON.

# Todo list

1. Update documentation for a recent rewrite.

# Build

To build the project, you need to:

1. Clone the repo to your machine.
2. Open the `.sln` file with your favourite IDE.
3. That's it!

# Installation

To use LibHKOSharp in your project, there are several ways to do so:

* Build the project and import the `.dll` files manually;
* Download from [NuGet Package Manager](https://www.nuget.org/packages/HKOSharp/);

# Usage

For the full usage of HKOSharp, you should check [HKOSharp Documentations](https://hkosharp.shingzh.eu.org).
> **WARNING: Library were rewritten recently and documentation may not be up-to-date.**

Here are some examples of usages of HKOSharp:

```c#
// Imports namespace
using HKOSharp.LibHKOSharp;
```

```c#
// Gets today's Local Weather Forecast
var localForecast = Weather.GetLocalForecast(Language.English);
Console.Write("Description of today's forecast: ");
Console.Write(localForecast.ForecastDesc);
// Output:
// Description of today's forecast: Under the influence of an anticyclone aloft, the weather is ...
```

```c#
// Gets latest Earthquake information
var eqInfo = Earthquake.GetLatestEqInfoAsnyc(Language.TraditionalChinese);
Console.Write("Latest Earthquake Report Region: ");
Console.Write(eqInfo.Region);
// Output:
// Latest Earthquake Report Region: 班達海
```

# Dependencies

* [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
* .NET Standard 2.0
