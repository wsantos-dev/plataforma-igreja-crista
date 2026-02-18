using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Identity.Entities;
using System.Security.Cryptography;

namespace PlataformaRedencao.Infra.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IHashingService _hashingService;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenService tokenService,
        IRefreshTokenRepository refreshTokenRepository,
        IHashingService hashingService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _refreshTokenRepository = refreshTokenRepository;
        _hashingService = hashingService;
    }

    public async Task<IReadOnlyCollection<(string id, string email, string userName)>> GetAllUserAsync()
    {
        return await _userManager.Users
         .Select(u => new ValueTuple<string, string, string>(
             u.Id,
             u.Email!,
             u.UserName!
         ))
         .ToListAsync();
    }

    public async Task<(string accessToken, string refreshToken)> RegisterAsync(string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));

        return await GenerateTokensAsync(user);
    }

    public async Task<(string accessToken, string refreshToken)> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            throw new Exception("Usuário ou senha inválidos.");

        var result = await _signInManager
            .CheckPasswordSignInAsync(user, password, false);

        if (!result.Succeeded)
            throw new Exception("Usuário ou senha inválidos.");

        return await GenerateTokensAsync(user);
    }

    private async Task<(string accessToken, string refreshToken)> GenerateTokensAsync(ApplicationUser user)
    {
        var accessToken = _tokenService.GenerateToken(user);

        var rawRefreshToken = Convert.ToBase64String(
            RandomNumberGenerator.GetBytes(64));

        var refreshTokenEntity = RefreshToken.Create(
            user.Id,
            rawRefreshToken,
            _hashingService,
            DateTimeOffset.UtcNow.AddDays(7));

        await _refreshTokenRepository.AddAsync(refreshTokenEntity);
        await _refreshTokenRepository.SaveChangesAsync();

        return (accessToken, rawRefreshToken);
    }
}
