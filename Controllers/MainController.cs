using Auth_Bearer_JWT.Models;
using Auth_Bearer_JWT.Repositories;
using Auth_Bearer_JWT.Service;
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
    }
}
