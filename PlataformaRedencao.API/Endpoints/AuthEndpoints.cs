using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using PlataformaRedencao.Infra.Identity.Entities;

namespace PlataformaRedencao.API.Endpoints;

public static class AuthEndpoints
{

    public record RegisterRequest(string Email, string Password, string? MemberId);
    public record LoginRequest(string Email, string Password);

    public static void MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/auth")
                       .WithTags("Auth")
                       .RequireAuthorization("AdminOnly");

        group.MapPost("/register", async (UserManager<ApplicationUser> userManager, RegisterRequest request) =>
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                MemberId = request.MemberId != null ? int.Parse(request.MemberId) : null
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return Results.BadRequest(result.Errors);

            return Results.Ok(new { user.Id, user.Email, user.MemberId });
        })
        .WithDisplayName("Register");

        group.MapPost("/login", async (SignInManager<ApplicationUser> signInManager, LoginRequest request) =>
        {
            var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);

            if (!result.Succeeded)
                return Results.BadRequest("Invalid credentials.");

            return Results.Ok("Logged in successfully");
        })
        .WithDisplayName("Login");
    }
}
