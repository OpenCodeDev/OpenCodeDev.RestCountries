namespace OpenCodeDev.RestCountries.Abstractions.Respositories
{
    public interface IRestCountriesRepository
    {
        Task<ICollection<Country>> GetAllAsync(CancellationToken cancellationToken);
        Task<ICollection<Country>> GetAnyAsync(Func<Country, bool> predicate, CancellationToken cancellationToken);
        Task<Country> GetByCCA2Code(string iso2, CancellationToken cancellationToken);
        Task<Country> GetByCCA3Code(string iso3, CancellationToken cancellationToken);
        Task<Country> GetByCCN3Code(string number, CancellationToken cancellationToken);

    }
}
