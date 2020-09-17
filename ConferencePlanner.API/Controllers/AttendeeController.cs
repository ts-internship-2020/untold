using System;
using System.Collections.Generic;
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
    public class AttendeeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly IButtons _buttons;

        public AttendeeController(IButtons getAttendeeButtonsRepository)
        {
            _buttons = getAttendeeButtonsRepository;
        }

        [HttpPost]
        [Route("Attend")]
        public IActionResult Attend(ButtonModel buttonModel)
        {
            _buttons.Attend(buttonModel);
            return Ok();
        }

        [HttpPost]
        [Route("WithdrawnButton")]
        public IActionResult WithdrawnCommand(ButtonModel buttonModel)
        {
            _buttons.WithdrawnCommand(buttonModel);
            return Ok();
        }

        [HttpPost]
        [Route("JoinButton")]
        public IActionResult JoinCommand(ButtonModel buttonModel)
        {
            _buttons.JoinCommand(buttonModel);
            return Ok();
        }
    }
}
