using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.OpenApi.Models; // Required for OpenApiInfo, OpenApiSecurityScheme, etc.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This line is crucial for discovering and registering your API controllers.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI for API documentation and testing.
// This includes setting up JWT Bearer authentication within Swagger UI itself.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Define the security scheme for JWT Bearer authentication in Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
    });

    // Require the "Bearer" security scheme for all operations in Swagger
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Configure JWT Bearer Authentication services.
// This tells the application how to validate incoming JWT tokens.
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Validate the server that issued the token
            ValidateAudience = true, // Validate the recipient of the token
            ValidateLifetime = true, // Validate the token's expiry
            ValidateIssuerSigningKey = true, // Validate the token's signature using the secret key
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Get issuer from appsettings.json
            ValidAudience = builder.Configuration["Jwt:Audience"], // Get audience from appsettings.json
            // Get the secret key from appsettings.json and convert it to bytes.
            // The '!' (null-forgiving operator) asserts that Configuration["Jwt:Key"] will not be null.
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

// Add Authorization services.
// This enables the use of [Authorize] attributes on controllers and actions.
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
// These middleware components process requests in a specific order.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development environment for API documentation.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Add Authentication middleware to the pipeline.
// This must come before UseAuthorization().
app.UseAuthentication();

// Add Authorization middleware to the pipeline.
// This must come after UseAuthentication().
app.UseAuthorization();

// Map controller routes to incoming requests.
// This is essential for your API endpoints to be accessible.
app.MapControllers();

// Run the application.
app.Run();