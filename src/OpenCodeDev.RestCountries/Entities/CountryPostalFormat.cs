namespace OpenCodeDev.RestCountries.Entities
{
    public record class CountryPostalFormat
    {
        public string Format { get; init; } = null!;
        public string Regex { get; init; } = null!;
    }
}
