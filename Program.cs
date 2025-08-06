using Grandeur_BE_DotNet.Data;
using Grandeur_BE_DotNet.Helpers;
using Grandeur_BE_DotNet.Middlewares;
using Grandeur_BE_DotNet.Repositories;
using Grandeur_BE_DotNet.Repositories.Implementation;
using Grandeur_BE_DotNet.Services;
using Grandeur_BE_DotNet.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
// builder.Services.AddOpenApi();

// Adding Db Context
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);

// Adding our Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adding our Services and Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();

// Adding Cloudinary
builder.Services.Configure<CloudinarySettings>(
    builder.Configuration.GetSection("CloudinarySettings"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

// Adding our Global exception handler middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

// Adding Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

// CORS
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Mapping the controllers
app.MapControllers();

app.Run();
