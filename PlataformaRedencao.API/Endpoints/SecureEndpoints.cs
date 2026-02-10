using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaRedencao.API.Endpoints
{
    public static class SecureEndpoints
    {
        public static WebApplication MapSecureEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/secure")
                           .WithTags("Secure")
                           .RequireAuthorization();

            group.MapGet("/me", MeAsync)
                 .WithName("Me")
                 .WithSummary("Usuário Logado");


            return app;
        }

        private static IResult MeAsync(HttpContext httpContext)
        {
            var usuarioId = httpContext.User.FindFirst("sub")?.Value;
            var email = httpContext.User.FindFirst("email")?.Value;

            return Results.Ok(new
            {
                usuarioId,
                email
            });
        }
    }
}