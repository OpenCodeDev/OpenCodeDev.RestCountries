namespace OpenCodeDev.RestCountries.Entities
{
    public record class CountryDemonym
    {
        public string LanguageCode { get; init; } = null!;
        public string Female { get; init; } = null!;
        public string Male { get; init; } = null!;
    }
}
