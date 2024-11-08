using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CepediFullStack.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Greet()
        {
            return Ok(new { msg = "hello!" });
        }
    }
}
