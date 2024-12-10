[![License: MPL 2.0](https://img.shields.io/badge/License-MPL_2.0-brightgreen.svg)](https://opensource.org/licenses/MPL-2.0)




# About this Project
This project is inspired on restcountries.eu by Fayder Florez.

This project is a direct .NET rewrite of [REST Countries Java] (Alejandro Matos).

## Important Information
* We are supporting [REST Countries Java] (Alejandro Matos) Version 3, Version 3.1 and plan the maintain compatibility.
* ***Versions will be updated according to [REST Countries Java] version updates.***
* ***Consider contribution to the JSON data for [REST Countries Java].***
## Pakages
### [OpenCodeDev.RestCountries](https://www.nuget.org/packages/OpenCodeDev.RestCountries)

[![](https://img.shields.io/nuget/v/OpenCodeDev.RestCountries?label=Latest)](https://www.nuget.org/packages/OpenCodeDev.RestCountries) 
[![](https://img.shields.io/nuget/dt/OpenCodeDev.RestCountries?label=Downloads)](https://www.nuget.org/packages/OpenCodeDev.RestCountries)

This .NET 8 based pakage contains the core behaviour for the RestCountries without any dependencies.
``` cs
var builder = WebApplication.CreateBuilder(args);
// this will make a singleton accessible through IRestCountries.
// replace RestCountriesEmbed.GetVersion("countriesV3.1") by your local or remote verson.json file.
builder.Services.AddRestCountriesServices(RestCountriesEmbed.GetVersion("countriesV3.1"));
```

### [OpenCodeDev.RestCountries.Embedded](https://www.nuget.org/packages/OpenCodeDev.RestCountries.Embedded)

[![](https://img.shields.io/nuget/v/OpenCodeDev.RestCountries.Embedded?label=Latest)](https://www.nuget.org/packages/OpenCodeDev.RestCountries.Embedded)
[![](https://img.shields.io/nuget/dt/OpenCodeDev.RestCountries?label=Downloads)](https://www.nuget.org/packages/OpenCodeDev.RestCountries)

Since Embedded includes all available JSON versions, it increases the package size, which may not be ideal for front-end deployments. 
However, it provides valuable resource files (all available versions) for server-side.

``` cs
var builder = WebApplication.CreateBuilder(args);
// this will make a singleton accessible through IRestCountries.
builder.Services.AddRestCountriesServices(RestCountriesEmbed.GetVersion("countriesV3.1"));

```

# Fields
You can check the [FIELDS.md](FIELDS.md) file to get info on each classes.


## Getting Started

``` cs
using OpenCodeDev.RestCountries.Embedded;

// Replace this to the json content of the version.json or use embeded content.
string jsonContentOfVersion = RestCountriesEmbed.GetVersion("countriesV3.1");
IRestCountries restCountries = new RestCountries(jsonContentOfVersion);
var countries = restCountries.GetAll();

```

## Check if Postal Required
``` cs
using OpenCodeDev.RestCountries.Embedded;

string jsonContentOfVersion = RestCountriesEmbed.GetVersion(version);
IRestCountries restCountries = new RestCountries(jsonContentOfVersion);
var countries = restCountries.GetAll();
var firstCountry = countries.First();
if (firstCountry.IsPostalRequired()) 
    Console.WriteLine($"{firstCountry.Name.Common} does require postal of format: {firstCountry.PostalFormat!.Format}");
else
    Console.WriteLine($"{firstCountry.Name.Common} does not require a postal.");

```

## Fetch Country by ISO-2 & Validate its postal code
``` cs
using OpenCodeDev.RestCountries.Embedded;

string jsonContentOfVersion = RestCountriesEmbed.GetVersion(version);
IRestCountries restCountries = new RestCountries(jsonContentOfVersion);
var countries = restCountries.GetAll();
// ca = Canada. You could also do CCA3 with CAN.
var firstCountry = restCountries.IsValidCCA2Code("ca");
if (restCountries.IsValidCCA2Code("ca"))
    if (restCountries.GetByCCA2Code("cA")!.IsPostalValid("H1A2T2")) 
        Console.WriteLine("H1A2T2 is a valid postal for Canada");
    else
        Console.WriteLine($"ca is not a valid country iso2.");

```

## More to Explore
Explore the other functions
``` cs
using OpenCodeDev.RestCountries.Embedded;

string jsonContentOfVersion = RestCountriesEmbed.GetVersion(version);
IRestCountries restCountries = new RestCountries(jsonContentOfVersion);
var countries = restCountries.GetAll();
if (restCountries.IsValidCCA2Code("ca")) Console.WriteLine("This is valid country code.");
if (restCountries.IsValidCCA3Code("can")) Console.WriteLine("This is valid country code.");
if (restCountries.IsValidCCA2PostalCode("ca", "H1T2S2")) Console.WriteLine("This is valid country code and postal.");
if (restCountries.IsValidCCA3PostalCode("can", "H1T2S2")) Console.WriteLine("This is valid country code and postal.");
if (restCountries.IsValidCCA2Currency("ca", "CAD")) Console.WriteLine("CAD is a valid Canadian Currency.");
if (restCountries.IsValidCCA3Currency("cad", "CAD")) Console.WriteLine("CAD is a valid Canadian Currency.");
if (restCountries.IsValidCCA3Currency("cad", "CAD")) Console.WriteLine("CAD is a valid Canadian Currency.");

var country = countries.First()!;
Console.WriteLine($"Phone Prefixes are {string.Join(',', country.PhonePrefixes())}");
```

## Similar projects
* [REST Countries Java] (original)
* [Countries of the world]
* [REST Countries Node.js]
* [REST Countries Ruby]
* [REST Countries Go]
* [REST Countries Python]
* [world-currencies]

[world-currencies]: https://github.com/wiredmax/world-currencies
[REST Countries Java]: https://gitlab.com/restcountries/restcountries
[REST Countries Node.js]: https://github.com/aredo/restcountries
[REST Countries Ruby]: https://github.com/davidesantangelo/restcountry
[REST Countries Go]: https://github.com/alediaferia/gocountries
[REST Countries Python]: https://github.com/SteinRobert/python-restcountries
[Countries of the world]: http://countries.petethompson.net
[Original Project]: https://github.com/apilayer/restcountries/
[donation]: https://www.paypal.me/amatosg/15
[donate]: https://www.paypal.me/amatosg/15
