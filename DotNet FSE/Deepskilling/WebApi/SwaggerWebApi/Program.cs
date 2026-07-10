using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models; // Required for Swagger OpenApiInfo

var builder = WebApplication.CreateBuilder(args);

// Add services to the container to enable Web API Controllers
builder.Services.AddControllers();

// Task 1: Add Swagger Generation Service
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "TBD",
        TermsOfService = new System.Uri("http://www.example.com"),
        Contact = new OpenApiContact() { Name = "John Doe", Email = "john@xyzmail.com", Url = new System.Uri("http://www.example.com") },
        License = new OpenApiLicense() { Name = "License Terms", Url = new System.Uri("http://www.example.com") }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseAuthorization();

// Task 1: Use Swagger Middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Specifying the Swagger JSON endpoint.
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
});

app.MapControllers(); 

app.Run();
