using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Registers controllers for your API
builder.Services.AddEndpointsApiExplorer(); // Required for Swagger to discover API endpoints
builder.Services.AddSwaggerGen(); // Configures Swagger generation services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enables the Swagger middleware
    app.UseSwaggerUI(); // Enables the Swagger UI (HTML, JS, CSS)
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS (if configured)
app.UseRouting(); // Enables routing for the application
app.UseAuthorization(); // Enables authorization middleware (if you add authentication/authorization later)

app.MapControllers(); // Maps controller actions to incoming requests

app.Run();
