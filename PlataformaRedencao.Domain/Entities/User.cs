using System.ComponentModel;

namespace PlataformaRedencao.Domain.Entities;

public sealed class User : BaseEntity
{
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;

    public bool IsActive { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    protected User() { }

    public User(string email, string senhaHash)
    {
        Email = email;
        PasswordHash = senhaHash;
        IsActive = true;
        CreatedAt = DateTimeOffset.UtcNow;
    }
    public void Desativar()
    {
        IsActive = false;
    }
}
