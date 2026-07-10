using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using EmployeeWebApi.Filters; // Import our custom filters

var builder = WebApplication.CreateBuilder(args);

// Add services to the container and globally register the Exception filter
builder.Services.AddControllers(options => 
{
    // Registering the CustomExceptionFilter globally
    options.Filters.Add<CustomExceptionFilter>();
});

// Add Swagger Generation Service
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee Web API", Version = "v1" });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

// Use Swagger Middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Web API");
});

app.MapControllers(); 

app.Run();
