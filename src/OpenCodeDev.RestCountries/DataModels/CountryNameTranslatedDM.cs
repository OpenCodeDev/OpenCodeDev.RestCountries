namespace OpenCodeDev.RestCountries.DataModels
{
    public record class CountryNameTranslatedDM
    {
        public string Common { get; init; } = null!;
        public string Official { get; init; } = null!;
    }
}
