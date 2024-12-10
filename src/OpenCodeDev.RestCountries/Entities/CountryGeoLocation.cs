namespace OpenCodeDev.RestCountries.Entities
{
    public record class CountryGeoLocation
    {
        public double Latitude { get; init; }
        public double Longitude { get; init; }
    }
}
