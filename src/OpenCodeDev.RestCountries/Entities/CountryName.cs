namespace OpenCodeDev.RestCountries.Entities
{
    public record class CountryName
    {
        public string Common { get; init; } = null!;
        public string Official { get; init; } = null!;
        public string LanguageCode { get; init; } = null!;
    }
}
