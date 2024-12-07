using OpenCodeDev.RestCountries.Entities.Enums;

namespace OpenCodeDev.RestCountries.Entities
{
    public record class CountryFlag
    {
        public string Value { get; init; } = null!;
        public FlagType Type { get; init; }
    }
}
