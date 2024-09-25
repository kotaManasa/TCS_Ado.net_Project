using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCS_Ado.net_Project.Interfaces;
using TCS_Ado.net_Project.Model_DTO;

namespace TCS_Ado.net_Project.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
          this._countriesService = countriesService;
        }

        [HttpGet(Name = "GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countryData = await _countriesService.GetAllCountriesDetails();
                if (countryData != null)
                {
                    return StatusCode(StatusCodes.Status200OK, countryData);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPost]
        [Route("AddCountryDetails")]
        public async Task<IActionResult> Post([FromBody] CountriesDTO countriesdtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _countriesService.AddCountryDetails(countriesdtoobj);
                return StatusCode(StatusCodes.Status201Created, "country Details Added Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpGet]
        [Route("GetCountriesDetailsById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var countryData = await _countriesService.GetCountriesDetailsById(id);
                if (countryData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "country Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, countryData);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpDelete]
        [Route("DeleteCountryDetilsById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var countryData = await _countriesService.DeleteCountryDetilsById(id);
                if (countryData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "country Id not found");
                }
                else
                {
                    var Data = await _countriesService.DeleteCountryDetilsById(id);
                    return StatusCode(StatusCodes.Status204NoContent, "country details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateCountryDetils")]
        public async Task<IActionResult> PUT([FromBody] CountriesDTO countriesdtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _countriesService.UpdateCountryDetils(countriesdtoobj);
                return StatusCode(StatusCodes.Status201Created, "country Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }



        [HttpGet]
        [Route("currentdatetime")]//restful API method
        public string getdateandtime()
        {
            return DateTime.Now.ToString();
        }

    }
}
