using Base.Proyecto.Common.Dto;
using Base.Proyecto.Common.Dto.Person;
using Base.Proyecto.Infraestructure.Models;
using Base.Proyecto.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.proyecto.WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            BodyResponse<object> result = _personService.GetAll();
            return !result.IsSuccess ? BadRequest(result) : Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            BodyResponse<object> result = _personService.GetById(id);
            return !result.IsSuccess ? BadRequest(result) : Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult AddRol(AddPersonDto model)
        {
            BodyResponse<object> result = _personService.Add(model);
            return !result.IsSuccess ? BadRequest(result) : Ok(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateRol(AddPersonDto rol)
        {
            BodyResponse<object> result = _personService.Update(rol);
            return !result.IsSuccess ? BadRequest(result) : Ok(result);
        }

        [HttpPut("delete/{id}")]
        public IActionResult DisablePerson(Guid id)
        {
            BodyResponse<object> result = _personService.Delete(id);
            return !result.IsSuccess ? BadRequest(result) : Ok(result);
        }
    }
}
