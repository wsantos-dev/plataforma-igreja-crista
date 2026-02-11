using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    public interface IChurchRepository : IRepository<Church>
    {
        Task<Church?> GetByCnpjAsync(string cnpj);
        Task<IEnumerable<Church>> GetByDenominationAsync(string denomination);
    }
}