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
using System.ComponentModel;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : Controller
    {
        
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerController( ISpeakerRepository speakerRepository)
        {

            _speakerRepository = speakerRepository;
        }


        [HttpGet]
        [Route("all_speakers")]
        public IActionResult GetAllSpeakers()
        {
            BindingList<SpeakerModel> speakers = _speakerRepository.GetAllSpeakers();
            return Ok(speakers);
        }

        [HttpGet]
        [Route("speaker_by_id")]
        public IActionResult GetSpeakerById(int id)
        {
            SpeakerModel speaker = _speakerRepository.GetSpeakerById(id);
            return Ok(speaker);
        }
        [HttpGet]
        [Route("speaker_by_name")]
        public IActionResult GetSpeakerByName(string[] names)
        {
            SpeakerModel speaker = _speakerRepository.GetSpeakerByName(names);
            return Ok(speaker);
        }
        [HttpPost]
        [Route("{DemoName}")]
        public IActionResult UpdateSpeaker(SpeakerModel speaker)
        {
            return Ok();
        }
        [HttpPost]
        [Route("{DemoName2}")]
        public IActionResult InsertSpeaker(SpeakerModel speaker)
        {
            return Ok();
        }
        [HttpDelete]
        [Route("{DemoName}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult DeleteSpeaker(int id)
        {
            return Ok();
        }
    }
}
