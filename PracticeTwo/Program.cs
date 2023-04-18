using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional:false, reloadOnChange: true)
    .AddEnvironmentVariables();

IConfiguration Configuration = configurationBuilder.Build(); 
string siteTitle = Configuration.GetSection("Title").Value;

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
app.UseSwagger();
app.UseSwaggerUI();
/*if (app.Environment.IsDevelopment())
{
    
}*/

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
