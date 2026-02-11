using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<Member?> GetByCpfAsync(string cpf, int churchId);
        Task<Member?> GetByEmailAsync(string email, int churchId);
        Task<IReadOnlyList<Member?>> GetByChurchAsync(int churchId);
        Task<IReadOnlyList<Member?>> GetActivesByChurchAsync(int churchId);
        Task<IReadOnlyList<Member?>> GetInactivesByChurchAsync(int churchId);
    }
}