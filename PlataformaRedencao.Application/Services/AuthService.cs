using PlataformaRedencao.Application.DTOs.Auth;
using PlataformaRedencao.Application.Security;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository usuarioRepository, IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateUsuarioAsync(RegisterUserRequestDTO requestDto)
        {
            var usuarioExistente = await _usuarioRepository.GetByEmailAsync(requestDto.Email);
            if (usuarioExistente is not null)
                throw new Exception("Usuário já cadastrado");

            var senhaHash = _passwordHasher.Hash(requestDto.Password);

            var usuario = new User(requestDto.Email, senhaHash);

            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task<User> LoginAsync(LoginRequestDTO requestDto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(requestDto.Email);
            if (usuario is null)
                throw new Exception("Credenciais inválidas.");

            var senhaValida = _passwordHasher.Verify(requestDto.Password, usuario.PasswordHash);
            if (!senhaValida)
                throw new Exception("Credenciais inválidas.");

            if (!usuario.IsActive)
                throw new Exception("Usuário inativo.");

            return usuario;
        }
    }
}