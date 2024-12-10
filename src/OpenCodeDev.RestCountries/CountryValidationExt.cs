using OpenCodeDev.RestCountries.Entities;
using System.Text.RegularExpressions;

namespace OpenCodeDev.RestCountries
{
    public static class CountryValidationExt
    {
        public static bool IsPostalRequired(this Country country)
            => country.PostalFormat != default;

        public static bool IsPostalValid(this Country country, string postal)
        {
            // only validate when not required if empty or null.
            if (country.PostalFormat == default) return string.IsNullOrWhiteSpace(postal);
            return Regex.IsMatch(postal, country.PostalFormat.Regex);
        }

        /// <summary>
        /// return list of prefixes to phones for the country +1, +230
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public static ICollection<string> PhonePrefixes(this Country country)
        => country.Identifier.RootSuffixes.Count >= 0 ?
            country.Identifier.RootSuffixes.Select(p => $"{country.Identifier.Root}{p}").ToList() :
            new() { country.Identifier.Root };

        public static bool HasPNGFlag(this Country country)
            => country.Flags.Any(p => p.Type == Entities.Enums.FlagType.PNG);

        public static bool HasSVGFlag(this Country country)
            => country.Flags.Any(p => p.Type == Entities.Enums.FlagType.SVG);

        public static bool HasALTTextForFlag(this Country country)
            => country.Flags.Any(p => p.Type == Entities.Enums.FlagType.AlternativeText);


        public static bool IsValidCurrency(this Country country, string currencyCode)
            => country.Currencies.Any(p => p.Code.Equals(currencyCode, StringComparison.CurrentCultureIgnoreCase));

        /// <summary>
        /// Return SVG if not available, returns PNG or throw not found error.
        /// </summary>
        public static string GetFlagURL(this Country country)
        {

            if (country.HasSVGFlag())
                return country.Flags.Single(p => p.Type == Entities.Enums.FlagType.SVG).Value;

            if (country.HasPNGFlag())
                return country.Flags.Single(p => p.Type == Entities.Enums.FlagType.PNG).Value;
            throw new Exception("No Flag available");
        }

    }
}
