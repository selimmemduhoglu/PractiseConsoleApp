using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRateLimiter(options =>
{ //ALGORÝTMALAR AÞAÐIDAKÝ GÝBÝDÝR ( buradaki isimleri controllerýn attribute üne yazmamýz yeterli hangisini yazarsak o servis algoritmasýný kullanýrýz. )
    //options.AddFixedWindowLimiter("Basic", _options =>
    //{
    //    _options.Window = TimeSpan.FromSeconds(12); //12 saniyede bir bu RateLimit özelliðini tekrarlayacak
    //    _options.PermitLimit = 4; // 12 saniye içerisinde 4 request atýlabilir þekilde ayarladý
    //    _options.QueueLimit = 2; //4 isteði aldýktan sonra geriye kalan isteklerden 2 tanesini kuyruða al demek.
    //    _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; //kuyrukta olan Ýsteklerin 12 saniye sonra iþleneceði zaman ki sýralamasýný ayarlar.    
    //});
    //AddFixedWindowLimiter

    //options.AddSlidingWindowLimiter("Sliding", _options =>
    //{
    //    _options.Window = TimeSpan.FromSeconds(12); 
    //    _options.PermitLimit = 4; 
    //    _options.QueueLimit = 2; 
    //    _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    //    _options.SegmentsPerWindow = 2; //her bir periyoudn kendisinden önceki sürece ne kadarlýk kota harcýyacaðýný ifade etmektedir. Bir sontraki requestin en fazla 2 hakkýný kullanabiiyoruz demektir.
    //});
    //AddSlidingWindowLimiter : Fixed Windows algoritamasýna benzerlik gödtermektedir. Her sabit sürede bir zaman aralýðýdnda istekleri sýnýrlandýrmaktadýr lakin sürenin yarýsýndan sonra diðer periyodun request kotasýný harcayacak þekilde istekleri karþýlar.

    //options.AddTokenBucketLimiter("TokenBucket", _options =>
    //{
    //    _options.TokenLimit = 4;
    //    _options.TokensPerPeriod= 4;
    //    _options.QueueLimit = 2;
    //    _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    //    _options.ReplenishmentPeriod = TimeSpan.FromSeconds(12);
    //});
    //Her bir periyotta iþlenecek request sayýsý kadat token  üretilecektir eðer bu tokenlar kullanýldýysa diðer periyottan borç alýnabilir. Lakin her periyoytta token üretim miktarý kadar token üretilecek ve bu þekilde ratelimit uygulanacaktýr þunu unutmamak lazýmdýr ki her periyodun  maximum  token limit verilen sabit sayý kadar olacaktýr.

    options.AddConcurrencyLimiter("Concurrency", _options =>
    {
        _options.PermitLimit = 4;
        _options.QueueLimit = 2;
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
    //Asenkron Requestleri sýnýrlandýrmak için kullanýlan bir algoritmadýr. her istek Concurrency sýnýrýný biðr azaltmakta ve bittikleri taktirde bu sýnýrý bir arttýrmaktadýrlar. Diðer algoritmalara nazana SADECE ASENKRON requestleri sýnýrlandýrýr. (Diðerleri deðil sadece asenkron olanlarý)


});

var app = builder.Build();

app.UseRateLimiter(); //RateLimit configuration ý için kullanýlan middleware dir.


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
