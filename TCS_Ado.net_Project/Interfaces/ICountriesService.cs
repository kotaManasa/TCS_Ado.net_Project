using TCS_Ado.net_Project.Model_DTO;

namespace TCS_Ado.net_Project.Interfaces
{
    public interface ICountriesService
    {
        Task<List<CountriesDTO>> GetAllCountriesDetails();
        Task<CountriesDTO> GetCountriesDetailsById(int id);
        Task<bool> AddCountryDetails(CountriesDTO countryDetail);
        Task<bool> UpdateCountryDetils(CountriesDTO countryDetail);
        Task<bool> DeleteCountryDetilsById(int id);
    }
}
