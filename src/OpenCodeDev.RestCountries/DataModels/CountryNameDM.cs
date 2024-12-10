namespace OpenCodeDev.RestCountries.DataModels
{
    public record class CountryNameDM
    {
        public string Common { get; init; } = null!;
        public string Official { get; init; } = null!;
        public Dictionary<string, CountryNameTranslatedDM> NativeName { get; init; } = null!;
    }
}
