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
    public class TypeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;
        //private readonly ITypeRepository _typeRepository;
        //public TypeController(ILogger<TypeController> logger, ITypeRepository typeRepository)
        //{
        //    _logger = (ILogger<HomeController>)logger;
        //    _typeRepository = typeRepository;
        //}

        //[HttpGet]
        //[Route("{Type}")]

        //public IActionResult GetConferenceType()
        //{
        //    BindingList<TypeModel> typelist = _typeRepository.GetConferenceType(Type);
        //    return Ok(typelist);
        //}

        //[HttpPost]
        //[Route("{Type}")]
        //public IActionResult UpdateType([FromRoute] TypeModel type)
        //{
        //    BindingList<TypeModel> typelist = _typeRepository.UpdateType(type);
        //    return Ok();
        //}

        //[HttpPost]
        //[Route("{Type}")]
        //public IActionResult InsertType([FromRoute] TypeModel type)
        //{
        //    BindingList<TypeModel> typelist = _typeRepository.InsertType(type);
        //    return Ok();
        //}






    }




    
}
