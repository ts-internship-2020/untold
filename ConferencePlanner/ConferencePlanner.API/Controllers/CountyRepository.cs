using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : Controller
    {
        private readonly ICountyRepository _countyRepository;


        public CountyController(ICountyRepository countyRepository)
        {
            _countyRepository = countyRepository;
        }

        [HttpGet]
        [Route("county_by_countryId/countryId={id}")]
        public IActionResult GetCountyList(int id)
        {
            BindingList<CountyModel> counties = _countyRepository.GetCountyList(id);
            return Ok(counties);
        }

        [HttpGet]
        [Route("county_last_id")]
        public IActionResult GetLastCountyId()
        {
            int LastId = _countyRepository.GetLastCountyId();
            return Ok(LastId);
        }

        [HttpPost]
        [Route("update_county")]
        public IActionResult UpdateCounty(CountyModel county)
        {
            _countyRepository.UpdateCounty(county);
            return Ok();
        }

        [HttpPost]
        [Route("insert_county")]
        public IActionResult InsertCounty(CountyModel county)
        {
            _countyRepository.InsertCounty(county);
            return Ok();
        }

        [HttpDelete]
        [Route("delete_county")]
        public IActionResult DeleteCounty(int countyId)
        {
            string error = _countyRepository.DeleteCounty(countyId);
            return Ok(error);
        }
    }
}
