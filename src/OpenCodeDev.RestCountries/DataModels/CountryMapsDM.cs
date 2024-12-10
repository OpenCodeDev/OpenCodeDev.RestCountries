namespace OpenCodeDev.RestCountries.DataModels
{
    public record class CountryMapsDM
    {
        public string GoogleMaps { get; init; } = null!;
        public string OpenStreetMaps { get; init; } = null!;
    }
}
