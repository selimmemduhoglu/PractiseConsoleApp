using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("Basic")] //Ratelimit configuration un hangi controller da kullan�laca��n� belirleyip� bu attribute � kullan�yoruz.(Bunu action seviyesinde de verebiliriz.)
  //DisablRateLimit] : Controller seviyesinde  devreye sokulmu� bir rate limit politikas�n�n action seviyes inde pasifle�tirilmesini sa�layan bir attribute dur.
    public class ValueController : ControllerBase
    {
        [HttpGet]
        
        public IActionResult Get()
        {
            return Ok();
        }

    }
}