using OpenCodeDev.RestCountries.DataModels;
using OpenCodeDev.RestCountries.Entities;
using OpenCodeDev.RestCountries.Entities.Mapping;
using OpenCodeDev.RestCountries.Mapping;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace OpenCodeDev.RestCountries
{
    public class RestCountries : IRestCountries
    {
        public ICollection<Country> Data { get; private set; } = new List<Country>();

        public ICollection<Country> GetAll() => Data;

        /// <summary>
        /// Pass eg: countriesV3.json's content
        /// </summary>
        /// <param name="jsonText"></param>
        public RestCountries(string jsonText)
        {
            var list = DeserializeCountries(jsonText);
            Data = ExtractToDataModels(list).Select(p => p.AsEntity()).ToList();
        }

        public List<JsonObject> DeserializeCountries(string dataText)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<List<JsonObject>>(dataText, options)!;
        }

        public List<CountryDM> ExtractToDataModels(List<JsonObject> jsonData)
        {
            List<CountryDM> preCountries = new List<CountryDM>();
            foreach (var item in jsonData)
            {
                item.ToJsonString();
                CountryDM country = item.Deserialize<CountryDM>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                country.Populate(item);
                preCountries.Add(country);
            }
            return preCountries;
        }


        public IEnumerable<Country> GetWhere(Func<Country, bool> predicate)
            => Data.Where(predicate);

        public Country? GetByCCA2Code(string iso2)
            => Data.SingleOrDefault(p => p.Identifier.CCA2.Equals(iso2, StringComparison.CurrentCultureIgnoreCase));

        public Country? GetByCCA3Code(string iso3)
            => Data.SingleOrDefault(p => p.Identifier.CCA3.Equals(iso3, StringComparison.CurrentCultureIgnoreCase));

        public Country? GetByCCN3Code(string number)
            => Data.SingleOrDefault(p => p.Identifier.CCN3.Equals(number, StringComparison.CurrentCultureIgnoreCase));

        // +141 5123 1234
        public bool IsValidCCA2PostalCode(string iso2, string postal)
        {
            var country = Data.SingleOrDefault(p => p.Identifier.CCA2.Equals(iso2, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.IsPostalValid(postal);
        }

        public bool IsValidCCN3PostalCode(string number, string postal)
        {
            var country = Data.SingleOrDefault(p => p.Identifier.CCN3.Equals(number, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.IsPostalValid(postal);
        }

        public bool IsValidCCA3PostalCode(string iso3, string postal)
        {
            var country = Data.SingleOrDefault(p => p.Identifier.CCA3.Equals(iso3, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.IsPostalValid(postal);
        }


        public bool IsValidCCA2Code(string iso2)
            => Data.Any(p => p.Identifier.CCA2.Equals(iso2, StringComparison.CurrentCultureIgnoreCase));

        public bool IsValidCCA3Code(string iso3)
        {
            var country = Data.SingleOrDefault(p => p.Identifier.CCA3.Equals(iso3, StringComparison.CurrentCultureIgnoreCase));
            return country != default;
        }

        public bool IsValidCCN3Code(string number)
        {
            var country = Data.SingleOrDefault(p => p.Identifier.CCN3.Equals(number, StringComparison.CurrentCultureIgnoreCase));
            return country != default;
        }


        public bool IsValidCCA2Currency(string countryISO2, string currencyISO3)
        {
            var country = Data.SingleOrDefault(p => p.Identifier.CCA2.Equals(countryISO2, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.Currencies.Any(p => p.Code.Equals(currencyISO3, StringComparison.CurrentCultureIgnoreCase));
        }

        public bool IsValidCCA3Currency(string countryISO3, string currencyISO3)
        {
            var country = Data.SingleOrDefault(p => p.Identifier.CCA3.Equals(countryISO3, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.IsValidCurrency(currencyISO3);
        }

        public bool IsValidCCN3Currency(string countryNumber, string currencyISO3)
        {
            var country = Data.SingleOrDefault(p => p.Identifier.CCN3.Equals(countryNumber, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.IsValidCurrency(currencyISO3);
        }


    }
}
