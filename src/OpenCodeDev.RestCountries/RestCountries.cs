using OpenCodeDev.RestCountries.Entities;
using System.Reflection;

namespace OpenCodeDev.RestCountries
{
    public class RestCountries
    {
        public ICollection<Country> Database { get; init; } = new List<Country>();

        public ICollection<Country> GetAll() => Database;

        RestCountries()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "countriesV3_1";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
            }
        }
        public IEnumerable<Country> GetWhere(Func<Country, bool> predicate)
            => Database.Where(predicate);

        public Country? GetByCCA2Code(string iso2)
            => Database.SingleOrDefault(p => p.Identifier.CCA2.Equals(iso2, StringComparison.CurrentCultureIgnoreCase));

        public Country? GetByCCA3Code(string iso3)
            => Database.SingleOrDefault(p => p.Identifier.CCA3.Equals(iso3, StringComparison.CurrentCultureIgnoreCase));

        public Country? GetByCCN3Code(string number)
            => Database.SingleOrDefault(p => p.Identifier.CCN3.Equals(number, StringComparison.CurrentCultureIgnoreCase));

        // +141 5123 1234
        public bool IsValidCCA2PostalCode(string iso2, string postal)
        {
            var country = Database.SingleOrDefault(p => p.Identifier.CCA2.Equals(iso2, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.IsPostalValid(postal);
        }

        public bool IsValidCCN3PostalCode(string number, string postal)
        {
            var country = Database.SingleOrDefault(p => p.Identifier.CCN3.Equals(number, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.IsPostalValid(postal);
        }

        public bool IsValidCCA3PostalCode(string iso3, string postal)
        {
            var country = Database.SingleOrDefault(p => p.Identifier.CCA3.Equals(iso3, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.IsPostalValid(postal);
        }


        public bool IsValidCCA2Code(string iso2)
            => Database.Any(p => p.Identifier.CCA2.Equals(iso2, StringComparison.CurrentCultureIgnoreCase));

        public bool IsValidCCA3Code(string iso3, CancellationToken cancellationToken)
        {
            var country = Database.SingleOrDefault(p => p.Identifier.CCA3.Equals(iso3, StringComparison.CurrentCultureIgnoreCase));
            return country != default;
        }

        public bool IsValidCCN3Code(string number, CancellationToken cancellationToken)
        {
            var country = Database.SingleOrDefault(p => p.Identifier.CCN3.Equals(number, StringComparison.CurrentCultureIgnoreCase));
            return country != default;
        }


        public bool IsValidCCA2Currency(string countryISO2, string currencyISO3)
        {
            var country = Database.SingleOrDefault(p => p.Identifier.CCA2.Equals(countryISO2, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.Currencies.Any(p => p.Code.Equals(currencyISO3, StringComparison.CurrentCultureIgnoreCase));
        }

        public bool IsValidCCA3Currency(string countryISO3, string currencyISO3)
        {
            var country = Database.SingleOrDefault(p => p.Identifier.CCA3.Equals(countryISO3, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.IsValidCurrency(currencyISO3);
        }

        public bool IsValidCCN3CurrencyAsync(string countryNumber, string currencyISO3)
        {
            var country = Database.SingleOrDefault(p => p.Identifier.CCN3.Equals(countryNumber, StringComparison.CurrentCultureIgnoreCase));
            if (country == default) throw new Exception("NotFound");
            return country.IsValidCurrency(currencyISO3);
        }


    }
}
