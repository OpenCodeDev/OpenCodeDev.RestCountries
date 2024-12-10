using OpenCodeDev.RestCountries.DataModels;
using OpenCodeDev.RestCountries.Entities.Enums;

namespace OpenCodeDev.RestCountries.Entities.Mapping
{
    public static class MappingExt
    {
        public static Country AsEntity(this CountryDM obj)
        {

            var result = new Country()
            {
                IsIndependent = obj.Independent == null ? false : (bool)obj.Independent,
                UnitedNationMember = obj.UNMember,
                BordersWith = obj.Borders,
                Continents = obj.Continents,
                GeoLocation = new CountryGeoLocation() { Latitude = obj.LATLNG[0], Longitude = obj.LATLNG[1] },
                Region = obj.Region,
                SubRegion = obj.SubRegion,
                StartWeekOn = obj.StartOfWeek,
                Status = obj.Status,
                TopLevelDomains = obj.TLD,
                Currencies = obj.Currencies.Select(p => p.AsEntity()).ToList(),
                Demonyms = obj.Demonyms.Select(p => p.AsEntity()).ToList(),
                Flags = obj.Flags.Select(p => p.AsCountryFlag()).ToList(),
                Languages = obj.Languages.Select(p => new CountryLanguage() { Code = p.Key, Name = p.Value }).ToList(),
                TranslatedNames = obj.Translations.Select(p => p.AsEntity()).ToList(),
                Timezones = obj.Timezones.Select(p => UTCOffsetConverter(p)).ToList(),
                PostalFormat = obj.PostalCode == default || obj.PostalCode.Format == null || obj.PostalCode.Regex == null ? default : new CountryPostalFormat() { Format = obj.PostalCode.Format, Regex = obj.PostalCode.Regex },
                Name = new CountryName() { LanguageCode = "EN", Common = obj.Name.Common, Official = obj.Name.Official },
                Identifier = new CountryIdentifier()
                {
                    CCA2 = obj.CCA2,
                    CCA3 = obj.CCA3,
                    CCN3 = obj.CCN3,
                    CIOC = obj.CIOC,
                    FIFA = obj.FIFA,
                    Root = obj.IDD.Root,
                    RootSuffixes = obj.IDD.Suffixes
                }
            };
            return result;
        }

        public static CountryName AsEntity(this KeyValuePair<string, CountryNameTranslatedDM> obj)
            => new()
            {
                LanguageCode = obj.Key,
                Official = obj.Value.Official,
                Common = obj.Value.Common
            };

        public static CountryFlag AsCountryFlag(this KeyValuePair<string, string> obj)
        {
            FlagType type = FlagType.Unknown;
            switch (obj.Key.ToLower())
            {
                case "png":
                    type = FlagType.PNG;
                    break;
                case "svg":
                    type = FlagType.SVG;
                    break;
                case "alt":
                    type = FlagType.AlternativeText;
                    break;
                default:
                    break;
            }
            return new CountryFlag()
            {
                Type = type,
                Value = obj.Value
            };
        }

        public static CountryDemonym AsEntity(this KeyValuePair<string, CountryDemonymDM> obj)
            => new()
            {
                Female = obj.Value.F,
                Male = obj.Value.M,
                LanguageCode = obj.Key
            };

        public static CountryCurrency AsEntity(this KeyValuePair<string, CountryCurrencyDM> obj)
            => new()
            {
                Code = obj.Key,
                Name = obj.Value.Name,
                Symbol = obj.Value.Symbol
            };


        /// <summary>
        /// Convert formatted UTC+07:00:00 to Timespan <br/>
        /// Supported Formats:<br/>
        /// UTC, UTC+07, UTC+07:00 and UTC+07:00:00
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static TimeSpan UTCOffsetConverter(string offset)
        {
            if (offset.Equals("UTC", StringComparison.InvariantCultureIgnoreCase)) return new TimeSpan(0, 0, 0);
            offset = offset.Replace("UTC", "");
            //offset += ":00";
            var tt = offset.Split(":")!;
            if (tt.Length <= 1)
                return new TimeSpan(int.Parse(tt[0]), 0, 00);
            else if (tt.Length == 2)
                return new TimeSpan(int.Parse(tt[0]), int.Parse(tt[1]), 00);
            else
                return new TimeSpan(int.Parse(tt[0]), int.Parse(tt[1]), int.Parse(tt[2]));


        }

    }
}
