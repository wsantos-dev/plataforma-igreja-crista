using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaRedencao.API.Endpoints
{
    /// <summary>
    /// Minimal API endpoints that require authentication (e.g. current user info).
    /// </summary>
    public static class SecureEndpoints
    {
        /// <summary>
        /// Maps secure (authorized) endpoints to the application.
        /// </summary>
        /// <param name="app">The <see cref="WebApplication"/> to map endpoints on.</param>
        /// <returns>The <see cref="WebApplication"/> for chaining.</returns>
        public static WebApplication MapSecureEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/secure")
                           .WithTags("Secure")
                           .RequireAuthorization();

            group.MapGet("/me", MeAsync)
                 .WithName("Me")
                 .WithSummary("Current user");


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