### Country Model
``` cs
public record class Country
{
    public CountryName Name { get; init; } = null!;
    public ICollection<string> TopLevelDomains { get; init; } = null!;
    public string Region { get; init; } = null!;
    public string SubRegion { get; init; } = null!;
    public string Status { get; init; } = null!;
    public bool UnitedNationMember { get; init; }
    public bool IsIndependent { get; init; }
    public CountryIdentifier Identifier { get; init; } = null!;
    public ICollection<string> Continents { get; init; } = null!;
    public ICollection<CountryLanguage> Languages { get; init; } = null!;
    public ICollection<CountryFlag> Flags { get; init; } = null!;
    public CountryPostalFormat? PostalFormat { get; init; }
    public ICollection<CountryCurrency> Currencies { get; init; } = null!;
    public string StartWeekOn { get; init; } = null!;
    public ICollection<TimeSpan> Timezones { get; init; } = null!;
    public ICollection<string> BordersWith { get; init; } = null!;
    public ICollection<CountryName> TranslatedNames { get; init; } = null!;
    public ICollection<CountryDemonym> Demonyms { get; init; } = null!;
    public CountryGeoLocation GeoLocation { get; init; } = null!;

}
```

### Country Currency
``` cs
public record class CountryCurrency
{
    public string Code { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string Symbol { get; init; } = null!;
}
```

### Country Demonym
``` cs
public record class CountryDemonym
{
    public string LanguageCode { get; init; } = null!;
    public string Female { get; init; } = null!;
    public string Male { get; init; } = null!;
}
```

### Country Flag
``` cs
public record class CountryFlag
{
    public string Value { get; init; } = null!;
    public FlagType Type { get; init; }
}
```

### Country GeoLocation
``` cs
public record class CountryGeoLocation
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }
}
```

### Country Identifier
``` cs
public record class CountryIdentifier
{
    public string CCA2 { get; init; } = null!;
    public string CCN3 { get; init; } = null!;

    public string CCA3 { get; init; } = null!;

    public string CIOC { get; init; } = string.Empty;
    public string FIFA { get; init; } = string.Empty;
    public string Root { get; init; } = null!;
    public ICollection<string> RootSuffixes { get; init; } = null!;
}
```

### Country Language
``` cs
public record class CountryLanguage
{
    public string Code { get; init; } = null!;
    public string Name { get; init; } = null!;
}
```

### Country Name
``` cs
public record class CountryName
{
    public string Common { get; init; } = null!;
    public string Official { get; init; } = null!;
    public string LanguageCode { get; init; } = null!;
}
```

### Country Postal Format
``` cs
public record class CountryPostalFormat
{
    public string Format { get; init; } = null!;
    public string Regex { get; init; } = null!;
}
```