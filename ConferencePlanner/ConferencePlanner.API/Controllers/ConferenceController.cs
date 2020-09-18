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
            ConferenceModelWithEmail conference = _conferenceRepository.GetConferenceById(id);
            return Ok(conference);
        }
        [HttpGet]
        [Route("conferenceModel_by_id/id={id}")]
        public IActionResult GetConferenceModelById(int id)
        {
            ConferenceModel conference = _conferenceRepository.GetConferenceModelById(id);
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

        [HttpGet]
        [Route("attendees_by_email/email={email}&pageSize={pageSize}&currentPage={currentPage}")]
        public IActionResult AttendeeConferences(string email,int pageSize,int currentPage)
        {
            List<ConferenceModel> conferences = _conferenceRepository.AttendeeConferences(email,pageSize,currentPage);
            return Ok(conferences);
        }
        [HttpGet]
        [Route("get_attendees_count/email={email}&sDate={sDate}&eDate={eDate}")]
        public IActionResult FilterAttendeesByDate(string email, string sDate, string eDate)
        {
            int count = _conferenceRepository.GetAtendeesCount(email, sDate, eDate);
            return Ok(count);
        }

        [HttpGet]
        [Route("attendees_by_page/email={email}&sIndex={sIndex}&eIndex={eIndex}&sDate={sDate}&eDate={eDate}")]
        public IActionResult GetAttendeesByPage(string email, int sIndex, int eIndex, string sDate, string eDate)
        {
            List<ConferenceModel> conferences = _conferenceRepository.GetAttendeesByPage(email, sIndex, eIndex, sDate, eDate);
            return Ok(conferences);
        }


        [HttpPost]
        [Route("add_conference")]
        public IActionResult InsertConference(ConferenceModelWithEmail conferenceModel)
        {
            _conferenceRepository.InsertConference(conferenceModel);
            return Ok();
        }
        [HttpPost]
        [Route("update_conference")]
        public IActionResult UpdateConference(ConferenceModelWithEmail conferenceModel)
        {
            _conferenceRepository.UpdateConference(conferenceModel);
            return Ok();
        }

        [HttpGet]
        [Route("filter_attendees_by_date/email={email}&sDate={sDate}&eDate={eDate}")]
        public IActionResult FilterAttendees(string email, string sDate, string eDate)
        {
           List<ConferenceModel> attendees =  _conferenceRepository.FilterAttendeesByDate(email, sDate, eDate);
            return Ok(attendees);
        }
    }
}
