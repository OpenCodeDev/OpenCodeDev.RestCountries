using OpenCodeDev.RestCountries.Entities;

namespace OpenCodeDev.RestCountries
{
    public interface IRestCountries
    {
        ICollection<Country> GetAll();
        IEnumerable<Country> GetWhere(Func<Country, bool> predicate);
        Country? GetByCCA2Code(string iso2);
        Country? GetByCCA3Code(string iso3);
        Country? GetByCCN3Code(string num);
        bool IsValidCCA2PostalCode(string iso2, string postal);
        bool IsValidCCA3PostalCode(string iso3, string postal);
        bool IsValidCCN3PostalCode(string num, string postal);

        bool IsValidCCA2Code(string iso2);
        bool IsValidCCA3Code(string iso3);
        bool IsValidCCN3Code(string num);

        bool IsValidCCA2Currency(string countryISO2, string currencyISO3);
        bool IsValidCCA3Currency(string countryISO3, string currencyISO3);
        bool IsValidCCN3Currency(string countryNum, string currencyISO3);
    }
}
