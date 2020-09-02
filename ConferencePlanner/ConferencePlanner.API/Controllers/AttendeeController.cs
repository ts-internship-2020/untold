using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferencePlanner.Abstraction.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConferencePlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;
        private readonly IAttendeeButtonsRepository _getAttendeeButtonsRepository;

        public AttendeeController(IAttendeeButtonsRepository getAttendeeButtonsRepository)
        {
            _getAttendeeButtonsRepository = getAttendeeButtonsRepository;
        }

        [HttpPost]
        //[Route("{AttendButton}")]
        public IActionResult Attend(string email, string barcode, int confId)
        {
            return Ok();
        }

        [HttpPost]
        //[Route("{WithdrawsnButton}")]
        public IActionResult WithdrawnCommand(String email, int confId)
        {
            _getAttendeeButtonsRepository.WithdrawnCommand(email, confId);
            return Ok();
        }

        [HttpPost]
        [Route("{JoinButton}")]
        public IActionResult JoinCommand(String email, int confId)
        {
            return Ok();
        }
    }
}
