using TCS_Ado.net_Project.Entity;

namespace TCS_Ado.net_Project.Interfaces
{
    public interface ICountriesRepository
    {
        Task<List<Countries>> GetAllCountriesDetails();
        Task<Countries> GetCountriesDetailsById(int id);
        Task<bool> AddCountryDetails(Countries countryDetail);
        Task<bool> UpdateCountryDetils(Countries countryDetail);
        Task<bool> DeleteCountryDetilsById(int id);
    }
}
