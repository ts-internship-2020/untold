using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {

            _cityRepository = cityRepository;
        }
        [HttpGet]
        [Route("getAllCitiesByCountyId={id}")]
        public IActionResult GetAlCities(int id)
        {
            BindingList<CityModel> speakers = _cityRepository.GetCitiesByCountyId(id);
            return Ok(speakers);
        }
        [HttpPost]
        [Route("DeleteCity")]
        public IActionResult DeleteCity(int id)
        {
            _cityRepository.DeleteCity(id);
            return Ok();
        }
    }
}
