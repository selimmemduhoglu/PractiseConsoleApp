using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly INumGenerator _numGenerator;
        public TestController(INumGenerator numGenerator)
        {
            _numGenerator = numGenerator;
        }


        [HttpGet]
        public String Get()
        {
            //NumGenerator _numGenerator = new();
            //int number = _numGenerator.GetRandomNumber();
            //_numGenerator = null;
            //return number.ToString(); ;
         

            int number = _numGenerator.RandomValue;

            return number.ToString(); ;
        }
    }
}
