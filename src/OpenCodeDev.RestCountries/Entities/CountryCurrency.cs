namespace OpenCodeDev.RestCountries.Entities
{
    public record class CountryCurrency
    {
        public string Code { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string Symbol { get; init; } = null!;
    }
}
