using PlataformaRedencao.Application.DTOs.Auth;
using PlataformaRedencao.Application.Security;
using PlataformaRedencao.Application.Services;

namespace PlataformaRedencao.API.Endpoints
{
    public static class AuthEndpoints
    {
        public static WebApplication MapAuthEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/auth")
                           .WithTags("Auth");

            group.MapPost("/cadastrar", CadastrarUsuarioAsync)
                 .WithName("CadastrarUsuario")
                 .WithSummary("Cadastrar usuário")
                 .WithDescription("Cria um novo usuário na plataforma");

            group.MapPost("/login", LoginAsync)
                 .WithName("Login")
                 .WithSummary("Login do usuário")
                 .WithDescription("Autentica o usuário e retorna os dados de acesso");


            return app;
        }

        private static async Task<IResult> LoginAsync(LoginRequestDTO requestDto,
            AuthService authService,
            IJwtTokenGenerator tokenGenerator)
        {
            if (requestDto is null)
                return Results.BadRequest("Requisição inválida.");

            var usuario = await authService.LoginAsync(requestDto);
            var token = tokenGenerator.GenerateToken(usuario);

            return Results.Ok(new
            {
                acessToken = token
            });
        }

        private static async Task<IResult> CadastrarUsuarioAsync(RegisterUserRequestDTO requestDto, AuthService authService)
        {
            await authService.CadastrarUsuarioAsync(requestDto);
            return Results.Ok();
        }
    }
}
