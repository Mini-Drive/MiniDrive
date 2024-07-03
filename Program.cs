using Microsoft.EntityFrameworkCore;
using MiniDrive.Infrastructure.Contexts;
using MiniDrive.App.Utils;
using MiniDrive.App.Implementations;
using MiniDrive.App.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MiniDrive.App.Services;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

//Configure context to conect at the database in azure whit sqlServer
builder.Services.AddDbContext<MiniDriveContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), Microsoft.EntityFrameworkCore.MySqlServerVersion.Parse("8.0.20-mysql")));

//Register AutoMapper and their perfiles
builder.Services.AddAutoMapper(typeof(FileProfile),typeof(FolderProfile),typeof(UserProfile));

// Scopes of the services
builder.Services.AddScoped<IUsers, UserRepository>();
builder.Services.AddScoped<IFiles, FileRepository>();
builder.Services.AddScoped<IFolders, FolderRepository>();
builder.Services.AddTransient<FileRepository>();
builder.Services.AddTransient<FolderRepository>();
builder.Services.AddTransient<FilesServices>();
builder.Services.AddTransient<FolderServices>();

//Configure the Cors for let it others applications can use the application
builder.Services.AddCors(options => options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// Builder for JWT with the token
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(configure =>
{
    configure.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = @Environment.GetEnvironmentVariable("JWTURL"),
        ValidAudience = @Environment.GetEnvironmentVariable("JWTURL"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3C7A6C4E2754B9A31F225E201C02D82E"))
    };
});


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

//permissions for disconnection
app.UseAuthorization();
app.UseAuthentication();

//Middlewares
app.MapControllers();

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
