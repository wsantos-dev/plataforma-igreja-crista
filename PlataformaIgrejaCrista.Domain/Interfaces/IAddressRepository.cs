using PlataformaIgrejaCrista.Domain.Entities;

namespace PlataformaIgrejaCrista.Domain.Interfaces
{
    /// <summary>
    /// Repository for persistence operations on <see cref="Address"/> entities.
    /// </summary>
    public interface IAddressRepository : IRepository<Address>
    { }
}