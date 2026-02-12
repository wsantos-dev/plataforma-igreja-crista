using PlataformaRedencao.Application.DTOs.Auth;
using PlataformaRedencao.Application.Security;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Service responsible for user authentication, registration, and related operations.
    /// </summary>
    public class AuthService
    {
        private readonly IUserRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;

        /// <summary>
        /// Initializes a new instance of <see cref="AuthService"/>.
        /// </summary>
        /// <param name="usuarioRepository">User repository.</param>
        /// <param name="passwordHasher">Password hasher.</param>
        public AuthService(IUserRepository usuarioRepository, IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Creates a new user from the provided registration data.
        /// </summary>
        /// <param name="requestDto">Registration data (email and password).</param>
        public async Task CreateUsuarioAsync(RegisterUserRequestDTO requestDto)
        {
            var usuarioExistente = await _usuarioRepository.GetByEmailAsync(requestDto.Email);
            if (usuarioExistente is not null)
                throw new Exception("User already registered.");

            var senhaHash = _passwordHasher.Hash(requestDto.Password);

            var usuario = new User(requestDto.Email, senhaHash);

            await _usuarioRepository.AddAsync(usuario);
        }

        /// <summary>
        /// Authenticates a user with the given credentials and returns the user entity.
        /// </summary>
        /// <param name="requestDto">Login credentials (email and password).</param>
        /// <returns>The authenticated user.</returns>
        public async Task<User> LoginAsync(LoginRequestDTO requestDto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(requestDto.Email);
            if (usuario is null)
                throw new Exception("Invalid credentials.");

            var senhaValida = _passwordHasher.Verify(requestDto.Password, usuario.PasswordHash);
            if (!senhaValida)
                throw new Exception("Invalid credentials.");

            if (!usuario.IsActive)
                throw new Exception("User is inactive.");

            return usuario;
        }
    }
}