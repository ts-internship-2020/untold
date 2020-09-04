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

       
        private readonly ITypeRepository _typeRepository;
        public TypeController(ITypeRepository typeRepository)
        {
           
            _typeRepository = typeRepository;
        }

        [HttpGet]
        [Route("GetTypes/")]

        public IActionResult GetConferenceType()
        {

            BindingList<TypeModel> types = _typeRepository.GetConferenceType();

            return Ok(types);
        }

        [HttpPost]
        [Route("UpdateType/id={id}")]
        public IActionResult UpdateType(TypeModel type)
        {
            _typeRepository.UpdateType(type);

            return Ok();
        }

        [HttpPost]
        [Route("InsertType")]
        public IActionResult InsertType(TypeModel typeModel)
        {
            _typeRepository.InsertType(typeModel);

            return Ok();
        }


        [HttpDelete]
        [Route("DeleteType/id={id}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult DeleteType(int id)
        {
            _typeRepository.DeleteType(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetTypeById/id={id}")]
        public IActionResult GetTypeById(int id)
        {

            TypeModel typeModel = _typeRepository.GetTypeById(id);

            return Ok(typeModel);
        }


    }





}
