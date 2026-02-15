using System.Text;
using PlataformaRedencao.API.Endpoints;
using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);


// Dependency injection
builder.Services.AddInfrastructure(builder.Configuration);


// Security
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);


builder.Services.AddAuthorization(options =>
{
    foreach (var role in Enum.GetNames(typeof(Roles)))
    {
        options.AddPolicy($"{role}Only",
            policy => policy.RequireRole(role));
    }
});


// Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new()
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter: Bearer { your token }"
    });

    c.AddSecurityRequirement(new()
    {
        {
            new()
            {
                Reference = new()
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});



// Global error handling
builder.Services.AddProblemDetails();

var app = builder.Build();

// Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler();
app.MapErrorEndpoints();
app.MapAdminEndpoints();

app.Run();

