using Microsoft.AspNetCore.Identity;
using PlataformaRedencao.Infra.Identity.Entities;

namespace PlataformaRedencao.Infra.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<string> RegisterAsync(string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception(errors);
        }

        return _tokenService.GenerateToken(user);
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            throw new Exception("Usuário ou senha inválidos.");

        var result = await _signInManager.CheckPasswordSignInAsync(
            user, password, false);

        if (!result.Succeeded)
            throw new Exception("Usuário ou senha inválidos.");

        return _tokenService.GenerateToken(user);
    }
}
