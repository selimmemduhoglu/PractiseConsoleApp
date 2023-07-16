using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly INumGenerator _numGenerator;
        private readonly INumGenerator2 _numGenerator2;
        public WeatherForecastController(INumGenerator numGenerator, INumGenerator2 numGenerator2) 
        {
            _numGenerator = numGenerator;
            _numGenerator2 = numGenerator2;
        } 
         
        [HttpGet]
        public String Get()
        {
            //NumGenerator _numGenerator = new();
            //int number =_numGenerator.GetRandomNumber();
            //int number = _numGenerator2.RandomValue;

            //int random1 = _numGenerator2.RandomValue;
            int random1 = _numGenerator.RandomValue;
            int random2 = _numGenerator2.GetNumGeneratorRandomNumber();

            return $"NumGenerator2.RandomValue : {random1} , NumGenerator.RandomValue: {random2}";
        }
    }
}

// Singleton : Uygulama ayaða kalktýktan sonra nesne çaðrýldýðýnda nesne sadece uygulamanýn ömrü boyunca bir kere çalýþýr ve ondan sonra her nesne çaðrýldýðýnda ilk oluþturulan nesne kullanýlýr.
// Scope : Uygulama ayaða kalktýktan sonra her request te nesne tekrardan üretilir
/* Transient : Uygulama ayaða kalktýktan sonra nesne her requestte tekrardan üretilmesinden ziyada daha fazla olrak her çaðrýlmada tekrardan üretilir.
Yani ayný requestin içinde çaðrýldýðýnda bile tekrardan nesneyi üretir fakat scope ta sadece request baþýna bir nesne üretileceði için ayný request içinde çaðrýldýðýnda bile sadece bir kere üretilecektir.   */