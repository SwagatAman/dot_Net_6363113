// Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models; // Required for OpenApiInfo, OpenApiContact, OpenApiLicense
using System; // Required for Uri

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Registers controllers for your API
builder.Services.AddEndpointsApiExplorer(); // Required for Swagger to discover API endpoints
builder.Services.AddSwaggerGen(c => // Configures Swagger generation services with custom info
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "TBD",
        TermsOfService = new Uri("https://www.example.com/terms"),
        Contact = new OpenApiContact { Name = "John Doe", Email = "john@xyzmail.com", Url = new Uri("https://www.example.com") },
        License = new OpenApiLicense { Name = "License Terms", Url = new Uri("https://www.example.com/license") }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enables the Swagger middleware
    app.UseSwaggerUI(c => // Enables the Swagger UI (HTML, JS, CSS)
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo"); // Specifies the Swagger JSON endpoint
    });
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS (if configured)
app.UseRouting(); // Enables routing for the application
app.UseAuthorization(); // Enables authorization middleware (if you add authentication/authorization later)

app.MapControllers(); // Maps controller actions to incoming requests

app.Run();