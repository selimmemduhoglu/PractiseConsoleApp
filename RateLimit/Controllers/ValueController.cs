using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("Basic")] //Ratelimit configuration un hangi controller da kullan�laca��n� belirleyip� bu attribute � kullan�yoruz
    public class ValueController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}