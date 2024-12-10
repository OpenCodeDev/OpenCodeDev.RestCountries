namespace OpenCodeDev.RestCountries.Entities
{
    public record class CountryLanguage
    {
        public string Code { get; init; } = null!;
        public string Name { get; init; } = null!;
    }
}
