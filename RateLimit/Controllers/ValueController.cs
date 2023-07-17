using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("Basic")] //Ratelimit configuration un hangi controller da kullanýlacaðýný belirleyipð bu attribute ü kullanýyoruz.(Bunu action seviyesinde de verebiliriz.)
  //DisablRateLimit] : Controller seviyesinde  devreye sokulmuþ bir rate limit politikasýnýn action seviyes inde pasifleþtirilmesini saðlayan bir attribute dur.
    public class ValueController : ControllerBase
    {
        [HttpGet]
        
        public IActionResult Get()
        {
            return Ok();
        }

    }
}