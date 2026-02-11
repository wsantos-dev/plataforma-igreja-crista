using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência para <see cref="Church"/>.
    /// </summary>
    public class ChurchRepository : IChurchRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ChurchRepository"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public ChurchRepository(PlataformaRedencaoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém uma Church pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da Church (pode ser nulo).</param>
        /// <returns>A entity <see cref="Church"/> ou <c>null</c> caso não exista.</returns>
        public async Task<Church?> GetByIdAsync(int? id)
            => await _context.Churches
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);

        /// <summary>
        /// Obtém todas as Igrejas.
        /// </summary>
        /// <returns>Uma coleção somente-leitura com todas as Churches.</returns>
        public async Task<IReadOnlyCollection<Church?>> GetAllAsync()
            => await _context.Churches
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Obtém uma Igreja pelo CNPJ.
        /// </summary>
        /// <param name="cnpj">CNPJ da Church.</param>
        /// <returns>A entity <see cref="Church"/> ou <c>null</c> caso não exista.</returns>
        public async Task<Church?> GetByCnpjAsync(string cnpj)
            => await _context.Churches
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Cnpj == cnpj);

        /// <summary>
        /// Obtém a Igreja pela denominação.
        /// </summary>
        /// <param name="denominacao">Denominação a ser pesquisada.</param>
        /// <returns>As Churches que correspondem à denominação informada.</returns>
        public async Task<IEnumerable<Church>> GetByDenominationAsync(string demomination)
            => await _context.Churches
            .AsNoTracking()
            .Where(i => i.Denomination == demomination)
            .ToListAsync();

        /// <summary>
        /// Adiciona uma nova Igreja e persiste no banco.
        /// </summary>
        /// <param name="entity">entity <see cref="Church"/> a ser adicionada.</param>
        /// <returns>A entity adicionada com possíveis valores gerados (ex.: Id).</returns>
        public async Task<Church> AddAsync(Church entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Atualiza uma Igreja existente e persiste as alterações.
        /// </summary>
        /// <param name="entity">entity <see cref="Church"/> a ser atualizada.</param>
        /// <returns>A entity atualizada.</returns>
        public async Task<Church> UpdateAsync(Church entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Remove uma Igreja e persiste a exclusão.
        /// </summary>
        /// <param name="entity">entity <see cref="Church"/> a ser removida.</param>
        /// <returns>A entity removida.</returns>
        public async Task<Church> DeleteAsync(Church entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}