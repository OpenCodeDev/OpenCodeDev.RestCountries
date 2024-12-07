using OpenCodeDev.RestCountries.Entities.Abstractions;

namespace OpenCodeDev.RestCountries.Abstractions.Services
{
    public interface IRestCountriesValidationService
    {
        Task<bool> IsValidCCN3Code(string number, CancellationToken cancellationToken);
        Task<bool> IsValidCCA2Code(string iso2, CancellationToken cancellationToken);
        Task<bool> IsValidCCA3Code(string iso2, CancellationToken cancellationToken);

        Task<bool> IsValidPostalCode(Country country, string postal);
        Task<bool> IsValidCCA2PostalCode(string iso2, string postal);
        Task<bool> IsValidCCA3PostalCode(string iso3, string postal);
        Task<bool> IsValidCCN3PostalCode(string number, string postal);

        Task<bool> IsValidCurrency(Country country, string iso3);
        Task<bool> IsValidCCA2Currency(string countryISO2, string currencyISO3);
        Task<bool> IsValidCCA3Currency(string countryISO3, string currencyISO3);
        Task<bool> IsValidCCN3Currency(string countryNumber, string currencyISO3);

    }
}
