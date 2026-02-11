using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência para <see cref="Endereco"/>.
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="AddressRepository"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public AddressRepository(PlataformaRedencaoDbContext context)
            => _context = context;

        /// <summary>
        /// Obtém um endereço pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do endereço.</param>
        /// <returns>A entity <see cref="Endereco"/> ou <c>null</c> caso não exista.</returns>
        public Task<Address?> GetByIdAsync(int? id)
            => _context.Addresses
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        /// <summary>
        /// Obtém todos os endereços registrados.
        /// </summary>
        /// <returns>Uma coleção de <see cref="Endereco"/> (pode estar vazia).</returns>
        public async Task<IReadOnlyCollection<Address?>> GetAllAsync()
            => await _context.Addresses
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Adiciona um novo endereço e persiste no banco.
        /// </summary>
        /// <param name="entity">entity a ser adicionada.</param>
        /// <returns>A entity adicionada com possíveis valores gerados (ex.: Id).</returns>
        public async Task<Address> AddAsync(Address entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        /// <summary>
        /// Atualiza um endereço existente e persiste as alterações.
        /// </summary>
        /// <param name="entity">entity com as alterações.</param>
        /// <returns>A entity atualizada.</returns>
        public async Task<Address> UpdateAsync(Address entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        /// <summary>
        /// Remove um endereço e persiste a exclusão.
        /// </summary>
        /// <param name="entity">entity a ser removida.</param>
        /// <returns>A entity removida.</returns>
        public async Task<Address> DeleteAsync(Address entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}