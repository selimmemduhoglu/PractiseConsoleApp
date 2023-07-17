using DependencyInjection;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Basic", _options =>
    {
        _options.Window = TimeSpan.FromSeconds(12); //12 saniyede bir bu RateLimit �zelli�ini tekrarlayacak
        _options.PermitLimit = 4; // 12 saniye i�erisinde 4 request at�labilir �ekilde ayarlad�
        _options.QueueLimit = 2; //4 iste�i ald�ktan sonra geriye kalan isteklerden 2 tanesini kuyru�a al demek.
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; //kuyrukta olan �steklerin 12 saniye sonra i�lenece�i zaman ki s�ralamas�n� ayarlar.    
    });
});

//builder.Services.AddSingleton<INumGenerator,NumGenerator>();
//builder.Services.AddScope<INumGenerator,NumGenerator>();
//builder.Services.AddTransient<INumGenerator,NumGenerator>();
builder.Services.AddTransient<INumGenerator, NumGenerator>();
builder.Services.AddTransient<INumGenerator2, NumGenerator2>();


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
