using TCS_Ado.net_Project.Entity;
using TCS_Ado.net_Project.Interfaces;
using TCS_Ado.net_Project.Model_DTO;
using TCS_Ado.net_Project.Repository;

namespace TCS_Ado.net_Project.Service
{
    public class CountriesService : ICountriesService
    {
        ICountriesRepository _countriesRepository;
        public CountriesService(ICountriesRepository CountriesRepository)
        {
            this._countriesRepository = CountriesRepository;
        }
        public async Task<bool> AddCountryDetails(CountriesDTO countryDetail)
        {
            Countries obj = new Countries();
            obj.id = countryDetail.id;
            obj.countryName = countryDetail.countryName;


            await _countriesRepository.AddCountryDetails(obj);
            return true;
        }

        public async Task<bool> DeleteCountryDetilsById(int id)
        {
            await _countriesRepository.DeleteCountryDetilsById(id);
            return true;
        }

        public async Task<List<CountriesDTO>> GetAllCountriesDetails()
        {
            List<CountriesDTO> objCountriesDto = new List<CountriesDTO>();
            var result = await _countriesRepository.GetAllCountriesDetails();
            foreach (Countries countriesObj in result)
            {
                CountriesDTO obj = new CountriesDTO();
                obj.id = countriesObj.id;
                obj.countryName = countriesObj.countryName;
                objCountriesDto.Add(obj);
            }
            return objCountriesDto;
        }

        public async Task<CountriesDTO> GetCountriesDetailsById(int id)
        {
            var countriesObj = await _countriesRepository.GetCountriesDetailsById(id);

            CountriesDTO countriesdtoobj = new CountriesDTO();
            countriesdtoobj.id = countriesObj.id;
            countriesdtoobj.countryName = countriesObj.countryName;
            return countriesdtoobj;
        }

        public async Task<bool> UpdateCountryDetils(CountriesDTO countryDetail)
        {
            Countries obj = new Countries();
            obj.id = countryDetail.id;
            obj.countryName = countryDetail.countryName;

            await _countriesRepository.UpdateCountryDetils(obj);
            return true;
        }
    }
}
