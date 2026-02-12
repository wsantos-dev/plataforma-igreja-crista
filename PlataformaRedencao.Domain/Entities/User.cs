using System.ComponentModel;

namespace PlataformaRedencao.Domain.Entities;

/// <summary>
/// Domain entity representing an application user (authentication and authorization).
/// </summary>
public sealed class User : BaseEntity
{
    /// <summary>User email address.</summary>
    public string EmailAddress { get; private set; } = null!;

    /// <summary>Hashed password.</summary>
    public string PasswordHash { get; private set; } = null!;

    /// <summary>Whether the user account is active.</summary>
    public bool IsActive { get; private set; }

    /// <summary>Creation timestamp.</summary>
    public DateTimeOffset CreatedAt { get; private set; }

    protected User() { }

    /// <summary>
    /// Creates a new user with the given email and password hash.
    /// </summary>
    /// <param name="email">Email address.</param>
    /// <param name="passwordHash">Hashed password.</param>
    public User(string email, string passwordHash)
    {
        EmailAddress = email;
        PasswordHash = passwordHash;
        IsActive = true;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Deactivates the user account.
    /// </summary>
    public void Desativar()
    {
        IsActive = false;
    }
}
