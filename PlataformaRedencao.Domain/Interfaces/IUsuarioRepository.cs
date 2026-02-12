using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    /// <summary>
    /// Repository for <see cref="User"/> entities with email lookup support.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Gets a user by email address, if one exists.
        /// </summary>
        /// <param name="email">User email address.</param>
        /// <returns>The user, or <c>null</c> if not found.</returns>
        Task<User?> GetByEmailAsync(string email);
    }
}