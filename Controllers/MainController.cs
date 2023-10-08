using Microsoft.AspNetCore.Mvc;

namespace Auth_Bearer_JWT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        public IActionResult Index() => Ok("Api Running...");
    }
}
