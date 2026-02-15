
using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.API.Endpoints
{
    public static class AdminEndpoints
    {
        public static WebApplication MapAdminEndpoints(this WebApplication app)
        {
            Console.WriteLine("AdminEndpoints foi chamado");

            var group = app.MapGroup("/admin")
                           .RequireAuthorization("AdminOnly")
                           .WithTags("Admin");

            group.MapPost("/dashboard", AdminDashoardAsync)
                 .WithName("AdminDashboard")
                 .WithSummary("Área Administrativa");

            return app;
        }
        private static IResult AdminDashoardAsync(HttpContext context)
        {
            return Results.Ok("Administration Area");
        }
    }
}