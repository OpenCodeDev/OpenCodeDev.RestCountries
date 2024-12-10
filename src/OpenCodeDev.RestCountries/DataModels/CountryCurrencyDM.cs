namespace OpenCodeDev.RestCountries.DataModels
{
    public record class CountryCurrencyDM
    {
        public string Name { get; init; } = null!;
        public string Symbol { get; init; } = null!;
    }
}
