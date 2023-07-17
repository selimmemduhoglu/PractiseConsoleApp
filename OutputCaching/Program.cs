var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOutputCache(); // service olarak ekledik

var app = builder.Build();



app.UseOutputCache(); // middleware olarak ekledik.

app.MapGet("/", () =>
{
    return Results.Ok(DateTime.UtcNow);
}).CacheOutput(); //burda üretilen çýktýýnýn cache lenmesi için kulolanýlýr default deðer ne kadarsa o kadar sürede cache licek




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
