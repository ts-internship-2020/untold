using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConferencePlanner.Api.Models;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Abstraction.Model;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : Controller
    {
        
        private readonly IGetDemoRepository _getDemoRepository;
        private readonly IConferenceRepository _conferenceRepository;

        public ConferenceController(IConferenceRepository conferenceRepository)
        {
            
            _conferenceRepository = conferenceRepository;
        }

        [HttpGet]
        [Route("get_conferences_by_date")]
        public IActionResult FilterConferencesByDate(string email, string sDate, string eDate)
        {
            List<ConferenceModel> conferences = _conferenceRepository.FilterConferencesByDate(email, sDate, eDate);
            return Ok(conferences);
        }


    }
}
