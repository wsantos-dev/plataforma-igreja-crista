namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// Request used to refresh an expired access token.
    /// </summary>
    public sealed class RefreshTokenRequestDTO
    {
        public string RefreshToken { get; set; } = null!;
    }
}
