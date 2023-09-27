using GymAPI.ModelsDTO;
using GymAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService= accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto model)
        {
            _accountService.RegisterUser(model);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto model)
        {
            string token = _accountService.GenerateJwt(model);
            return Ok(token);
        }

    }
}
