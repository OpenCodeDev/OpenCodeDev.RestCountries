using System.Text.Json.Serialization;

namespace OpenCodeDev.RestCountries.DataModels
{
    public record class CountryDM
    {
        public CountryNameDM Name { get; init; } = null!;
        public string CCA2 { get; init; } = null!;
        public string CCA3 { get; init; } = null!;
        public string CCN3 { get; init; } = null!;
        public string CIOC { get; init; } = null!;
        public string FIFA { get; init; } = null!;
        public bool? Independent { get; init; }
        public string Status { get; init; } = null!;
        public bool UNMember { get; init; }
        public bool LandLocked { get; init; }
        public string Region { get; init; } = null!;
        public string SubRegion { get; init; } = null!;
        public double Area { get; init; }
        public string Flag { get; init; } = null!;
        public int Population { get; init; }
        public string StartOfWeek { get; init; } = null!;
        public CountryMapsDM Maps { get; init; } = null!;
        public List<string> TLD { get; init; } = null!;
        [JsonIgnore]
        public Dictionary<string, CountryCurrencyDM> Currencies { get; init; } = new Dictionary<string, CountryCurrencyDM>();
        public CountryIdentityDM IDD { get; init; } = null!;
        public List<string> Capital { get; init; } = null!;
        public CountryCapitalInfoDM CapitalInfo { get; init; } = null!;
        public List<string> AltSpelling { get; init; } = null!;
        public List<string> Continents { get; init; } = null!;
        public List<string> Borders { get; init; } = null!;
        public List<string> Timezones { get; init; } = null!;
        public Dictionary<string, string> Languages { get; init; } = null!;
        [JsonIgnore]
        public Dictionary<string, CountryNameTranslatedDM> Translations { get; init; } = new();
        [JsonIgnore]
        public Dictionary<string, CountryDemonymDM> Demonyms { get; init; } = new();
        public double[] LATLNG { get; init; } = null!;
        [JsonIgnore]
        public Dictionary<string, string> Flags { get; init; } = new();
        public Dictionary<string, string> CoatOfArms { get; init; } = null!;
        public CountryPostalDM PostalCode { get; init; } = null!;

    }
}
