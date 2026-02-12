namespace PlataformaRedencao.Application.DTOs.Auth
{
    /// <summary>
    /// DTO for user registration request (email and password).
    /// </summary>
    public class RegisterUserRequestDTO
    {
        /// <summary>User email address.</summary>
        public string Email { get; set; } = null!;

        /// <summary>User password.</summary>
        public string Password { get; set; } = null!;
    }
}