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
        
       
        private readonly IConferenceRepository _conferenceRepository;

        public ConferenceController(IConferenceRepository conferenceRepository)
        {
            
            _conferenceRepository = conferenceRepository;
        }

        [HttpGet]
        [Route("conferences_by_date/email={email}&sDate={sDate}&endDate={eDate}")]
        public IActionResult FilterConferencesByDate(string email, string sDate, string eDate)
        {
            List<ConferenceModel> conferences = _conferenceRepository.FilterConferencesByDate(email, sDate, eDate);
            return Ok(conferences);
        }
        [HttpGet]
        [Route("conferences_by_organizer/email={email}")]
        public IActionResult GetConferencesByOrganizer(string email)
        {
            List<ConferenceModel> conferences = _conferenceRepository.GetConferencesByOrganizer(email);
            return Ok(conferences);
        }
        [HttpGet]
        [Route("conference_by_id/id={id}")]
        public IActionResult GetConferenceById(int id)
        {
            ConferenceModel conference = _conferenceRepository.GetConferenceById(id);
            return Ok(conference);
        }

        [HttpGet]
        [Route("conferences_by_page/email={email}&sIndex={startIndex}&eIndex={endIndex}&sDate={sDate}&eDate={eDate}")]
        public IActionResult GetConferenceByPage(string email, int startIndex, int endIndex, string sDate, string eDate)
        {
            List<ConferenceModel> conferences = _conferenceRepository.GetConferencesByPage(email, startIndex, endIndex, sDate, eDate);
            return Ok(conferences);
        }

        [HttpDelete]
        [Route("delete_conference/id={id}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult DeleteConferenceById(int id)
        {
            _conferenceRepository.DeleteConferenceById(id);
            return Ok();
        }

    }
}
