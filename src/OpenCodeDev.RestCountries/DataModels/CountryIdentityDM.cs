namespace OpenCodeDev.RestCountries.DataModels
{
    public record class CountryIdentityDM
    {
        public string Root { get; init; } = null!;
        public List<string> Suffixes { get; init; } = null!;
    }
}
