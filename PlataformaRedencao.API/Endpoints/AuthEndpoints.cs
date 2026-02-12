using PlataformaRedencao.Application.DTOs.Auth;
using PlataformaRedencao.Application.Security;
using PlataformaRedencao.Application.Services;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.API.Endpoints
{
    /// <summary>
    /// Minimal API endpoints for authentication (register, login, refresh, logout).
    /// </summary>
    public static class AuthEndpoints
    {
        /// <summary>
        /// Maps authentication endpoints to the application.
        /// </summary>
        /// <param name="app">The <see cref="WebApplication"/> to map endpoints on.</param>
        /// <returns>The <see cref="WebApplication"/> for chaining.</returns>
        public static WebApplication MapAuthEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/auth")
                           .WithTags("Auth");

            group.MapPost("/create", CreateUsuarioAsync)
                 .WithName("CreateUser")
                 .WithSummary("Register user")
                 .WithDescription("Creates a new user on the platform");

            group.MapPost("/login", LoginAsync)
                 .WithName("Login")
                 .WithSummary("User login")
                 .WithDescription("Authenticates the user and returns access data");

            group.MapPost("/refresh", RefreshTokenAsync)
                 .WithName("Refresh")
                 .WithSummary("Refresh Token JWT");

            group.MapPost("/logout", LogoutAsync)
                 .WithName("Logout")
                 .WithSummary("Logs out from the platform");

            return app;
        }

        private static async Task<IResult> LogoutAsync(
           string refreshToken,
           IRefreshTokenRepository refreshRepo)
        {
            var token = await refreshRepo.GetAsync(refreshToken);

            if (token != null)
                await refreshRepo.RevokeAsync(token);

            return Results.Ok();
        }

        private static async Task<IResult> RefreshTokenAsync(
        string refreshToken,
        IRefreshTokenRepository refreshRepo,
        IUserRepository usuarioRepo,
        IJwtTokenGenerator jwtTokenGenerator)
        {
            var storedToken = await refreshRepo.GetAsync(refreshToken);

            if (storedToken == null || !storedToken.IsValid())
                return Results.Unauthorized();

            var user = await usuarioRepo.GetByIdAsync(storedToken.UsuarioId);
            if (user == null)
                return Results.Unauthorized();

            await refreshRepo.RevokeAsync(storedToken);

            var newAccessToken = jwtTokenGenerator.GenerateToken(user);

            return Results.Ok(new
            {
                accessToken = newAccessToken
            });
        }
        private static async Task<IResult> LoginAsync(LoginRequestDTO requestDto,
            AuthService authService,
            IJwtTokenGenerator tokenGenerator,
            IRefreshTokenGenerator refreshGenerator,
            IRefreshTokenRepository refreshRepo)
        {
            if (requestDto is null)
                return Results.BadRequest("Invalid request.");

            var usuario = await authService.LoginAsync(requestDto);
            var token = tokenGenerator.GenerateToken(usuario);

            var refreshTokenValue = refreshGenerator.Generate();
            var refreshToken = new RefreshToken(
                usuario.Id,
                refreshTokenValue,
                DateTimeOffset.UtcNow.AddDays(7)
            );

            await refreshRepo.AddAsync(refreshToken);

            return Results.Ok(new
            {
                acessToken = token,
                refreshToken = refreshTokenValue
            });
        }

        private static async Task<IResult> CreateUsuarioAsync(RegisterUserRequestDTO requestDto, AuthService authService)
        {
            await authService.CreateUsuarioAsync(requestDto);
            return Results.Ok();
        }
    }
}
