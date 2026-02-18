using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using PlataformaRedencao.Application.Exceptions;
using PlataformaRedencao.Domain.Messages;
using PlataformaRedencao.Infra.Identity.Entities;
using PlataformaRedencao.Infra.Identity.Services;

namespace PlataformaRedencao.API.Endpoints;

public static class AuthEndpoints
{
    public record RegisterRequest(string Email, string Password);
    public record LoginRequest(string Email, string Password);

    public static void MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/auth")
                       .WithTags("Auth");

        group.MapGet("/", async (IIdentityService identityService) =>
        {
            var users = await identityService.GetAllUserAsync();
            return Results.Ok(users);

        })
        .WithDisplayName("GetAllUsers");

        group.MapPost("/register", async (IIdentityService identityService, RegisterRequest request) =>
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email
            };

            var (accessToken, refreshToken) = await identityService.RegisterAsync(request.Email, request.Password);


            return Results.Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        })
        .WithDisplayName("Register");

        group.MapPost("/login", async (IIdentityService identityService, LoginRequest request) =>
        {
            var (accessToken, refreshToken) = await identityService.LoginAsync(
                request.Email,
                request.Password
            );

            return Results.Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        })
        .WithDisplayName("Login");
    }
}
