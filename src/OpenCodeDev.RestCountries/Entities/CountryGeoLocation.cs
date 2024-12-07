namespace OpenCodeDev.RestCountries.Entities
{
    public record class CountryGeoLocation
    {
        public string Latitude { get; init; } = null!;
        public string Longitude { get; init; } = null!;
    }
}
