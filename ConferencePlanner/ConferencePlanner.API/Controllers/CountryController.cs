using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {

            _countryRepository = countryRepository;
        }


        [HttpPost]
        [Route("insert_country")]
        public IActionResult InsertCountry(CountryModel country)
        {
            _countryRepository.InsertCountry(country);
            return Ok();
        }

        [HttpPost]
        [Route("update_country")]
        public IActionResult UpdateCountry(CountryModel country)
        {
            _countryRepository.UpdateCountry(country);
            return Ok();
        }

        [HttpDelete]
        [Route("delete_country")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult DeleteCountry(int id)
        {
            _countryRepository.DeleteCountry(id);
            return Ok();
        }

        [HttpGet]
        [Route("get_country_id_by_conference_id/id={conferenceId}")]
        public IActionResult GetCountryIdByConferenceId(int conferenceId)
        {
            int countryId = _countryRepository.GetCountryIdByConferenceId(conferenceId);
            return Ok(countryId);
        }

    }
}
