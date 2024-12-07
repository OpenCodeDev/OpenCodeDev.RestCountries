namespace OpenCodeDev.RestCountries.Entities
{
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
        public ICollection<TimeZoneInfo> Timezones { get; init; } = null!;
        public ICollection<string> BordersWith { get; init; } = null!;
    }
}
