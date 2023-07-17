using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("Basic")] //Ratelimit configuration un hangi controller da kullanýlacaðýný belirleyipð bu attribute ü kullanýyoruz
    public class ValueController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}