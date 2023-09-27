using Base.Proyecto.Common.Dto.AppUser;
using Base.Proyecto.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Base.proyecto.WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Authenticate")]

        public IActionResult Authenticate(LoginRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }
    }
}
