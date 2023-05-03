using Microsoft.OpenApi.Models;
using UPB.CoreLogic.Managers;
using UPB.PracticeTwo.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args); //Servidor

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional:false, reloadOnChange: true)
    .AddEnvironmentVariables();

IConfiguration Configuration = configurationBuilder.Build(); 
string siteTitle = Configuration.GetSection("Title").Value;
var environment = Configuration.GetValue<string>("Environment");

//creating the logger and setting up sinks, filters and properties
LoggerConfiguration loggerConfiguration;
if (environment == "Development")
{
    loggerConfiguration = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("logs/DEV.log", rollingInterval: RollingInterval.Day);
}
else
{
    loggerConfiguration = new LoggerConfiguration()
        .WriteTo.File("logs/QA.log", rollingInterval: RollingInterval.Day);
}

Log.Logger = loggerConfiguration.CreateBootstrapLogger();

//after create the builder - UseSerilog
builder.Host.UseSerilog();

// Add services to the container.(Servicios)
builder.Services.AddTransient<PatientManager>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = siteTitle
    });
});

//Levantarlo
var app = builder.Build();

// Configure the HTTP request pipeline. (Configuración)
app.UseGlobalExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
