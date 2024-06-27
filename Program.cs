using Microsoft.EntityFrameworkCore;
using MiniDrive.Infrastructure.Contexts;
using MiniDrive.App.Utils;
using MiniDrive.App.Implementations;
using MiniDrive.App.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure context to conect at the database in azure whit sqlServer
builder.Services.AddDbContext<MiniDriveContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Register AutoMapper and their perfiles
builder.Services.AddAutoMapper(typeof(FileProfile),typeof(FolderProfile),typeof(UserProfile));

// Scopes de los servicios
builder.Services.AddScoped<IUsers, UserRepository>();

//Configure the Cors for let it others applications can use the application
builder.Services.AddCors(options => options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

//Configure the options of Cors
app.UseCors("AllowAnyOrigin");

//Map all endpoints
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
