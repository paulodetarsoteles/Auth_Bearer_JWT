using Auth_Bearer_JWT.Models;
using Auth_Bearer_JWT.Repositories;
using Auth_Bearer_JWT.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Bearer_JWT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        public IActionResult Index() => Ok("Api Running...");

        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] User model)
        {
            User? user = UserRepository.Get(model.Name, model.Password);

            if (user is null)
                return NotFound("Usuário ou senha inválidos");

            string token = TokenService.GenerateToken(user);

            user.Password = "****";

            return Ok(new { user = user, token = token });
        }

        [HttpGet("anonimo")]
        [AllowAnonymous]
        public IActionResult Anonymous() => Ok();

        [HttpGet("autenticado")]
        [Authorize]
        public IActionResult Authenticated() => Ok($"Usuário autenticado: {User.Identity.Name}");

        [HttpGet("funcionario")]
        [Authorize(Roles = "boss, employee")]
        public IActionResult EmployeeArea() => Ok("Acesso concedido!");

        [HttpGet("chefe")]
        [Authorize(Roles = "boss")]
        public IActionResult BossArea() => Ok("Acesso concedido!");
    }
}
