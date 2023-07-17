using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRateLimiter(options =>
{ //ALGOR�TMALAR A�A�IDAK� G�B�D�R ( buradaki isimleri controller�n attribute �ne yazmam�z yeterli hangisini yazarsak o servis algoritmas�n� kullan�r�z. )
    //options.AddFixedWindowLimiter("Basic", _options =>
    //{
    //    _options.Window = TimeSpan.FromSeconds(12); //12 saniyede bir bu RateLimit �zelli�ini tekrarlayacak
    //    _options.PermitLimit = 4; // 12 saniye i�erisinde 4 request at�labilir �ekilde ayarlad�
    //    _options.QueueLimit = 2; //4 iste�i ald�ktan sonra geriye kalan isteklerden 2 tanesini kuyru�a al demek.
    //    _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; //kuyrukta olan �steklerin 12 saniye sonra i�lenece�i zaman ki s�ralamas�n� ayarlar.    
    //});
    //AddFixedWindowLimiter

    //options.AddSlidingWindowLimiter("Sliding", _options =>
    //{
    //    _options.Window = TimeSpan.FromSeconds(12); 
    //    _options.PermitLimit = 4; 
    //    _options.QueueLimit = 2; 
    //    _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    //    _options.SegmentsPerWindow = 2; //her bir periyoudn kendisinden �nceki s�rece ne kadarl�k kota harc�yaca��n� ifade etmektedir. Bir sontraki requestin en fazla 2 hakk�n� kullanabiiyoruz demektir.
    //});
    //AddSlidingWindowLimiter : Fixed Windows algoritamas�na benzerlik g�dtermektedir. Her sabit s�rede bir zaman aral���dnda istekleri s�n�rland�rmaktad�r lakin s�renin yar�s�ndan sonra di�er periyodun request kotas�n� harcayacak �ekilde istekleri kar��lar.

    //options.AddTokenBucketLimiter("TokenBucket", _options =>
    //{
    //    _options.TokenLimit = 4;
    //    _options.TokensPerPeriod= 4;
    //    _options.QueueLimit = 2;
    //    _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    //    _options.ReplenishmentPeriod = TimeSpan.FromSeconds(12);
    //});
    //Her bir periyotta i�lenecek request say�s� kadat token  �retilecektir e�er bu tokenlar kullan�ld�ysa di�er periyottan bor� al�nabilir. Lakin her periyoytta token �retim miktar� kadar token �retilecek ve bu �ekilde ratelimit uygulanacakt�r �unu unutmamak laz�md�r ki her periyodun  maximum  token limit verilen sabit say� kadar olacakt�r.

    options.AddConcurrencyLimiter("Concurrency", _options =>
    {
        _options.PermitLimit = 4;
        _options.QueueLimit = 2;
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
    //Asenkron Requestleri s�n�rland�rmak i�in kullan�lan bir algoritmad�r. her istek Concurrency s�n�r�n� bi�r azaltmakta ve bittikleri taktirde bu s�n�r� bir artt�rmaktad�rlar. Di�er algoritmalara nazana SADECE ASENKRON requestleri s�n�rland�r�r. (Di�erleri de�il sadece asenkron olanlar�)


});

var app = builder.Build();

app.UseRateLimiter(); //RateLimit configuration � i�in kullan�lan middleware dir.


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
