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

// Singleton : Uygulama aya�a kalkt�ktan sonra nesne �a�r�ld���nda nesne sadece uygulaman�n �mr� boyunca bir kere �al���r ve ondan sonra her nesne �a�r�ld���nda ilk olu�turulan nesne kullan�l�r.
// Scope : Uygulama aya�a kalkt�ktan sonra her request te nesne tekrardan �retilir
/* Transient : Uygulama aya�a kalkt�ktan sonra nesne her requestte tekrardan �retilmesinden ziyada daha fazla olrak her �a�r�lmada tekrardan �retilir.
Yani ayn� requestin i�inde �a�r�ld���nda bile tekrardan nesneyi �retir fakat scope ta sadece request ba��na bir nesne �retilece�i i�in ayn� request i�inde �a�r�ld���nda bile sadece bir kere �retilecektir.   */