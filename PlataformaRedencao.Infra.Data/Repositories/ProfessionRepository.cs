using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência para <see cref="Profession"/>.
    /// </summary>
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProfessionRepository"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public ProfessionRepository(PlataformaRedencaoDbContext context)
            => _context = context;

        /// <summary>
        /// Obtém uma profissão pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador da profissão.</param>
        /// <returns>A entity <see cref="Profession"/> ou <c>null</c> caso não exista.</returns>
        public async Task<Profession?> GetByIdAsync(int? id)
            => await _context.Professions
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        /// <summary>
        /// Obtém todas as profissões registradas.
        /// </summary>
        /// <returns>Uma coleção de <see cref="Profession"/> (pode estar vazia).</returns>
        public async Task<IReadOnlyCollection<Profession?>> GetAllAsync()
            => await _context.Professions
            .AsNoTracking()
            .ToListAsync();

        /// <summary>
        /// Adiciona uma nova profissão e persiste no banco.
        /// </summary>
        /// <param name="entity">entity a ser adicionada.</param>
        /// <returns>A entity adicionada com possíveis valores gerados (ex.: Id).</returns>
        public async Task<Profession> AddAsync(Profession entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Atualiza uma profissão existente e persiste as alterações.
        /// </summary>
        /// <param name="entity">entity com as alterações.</param>
        /// <returns>A entity atualizada.</returns>
        public async Task<Profession> UpdateAsync(Profession entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Remove uma profissão e persiste a exclusão.
        /// </summary>
        /// <param name="entity">entity a ser removida.</param>
        /// <returns>A entity removida.</returns>
        public async Task<Profession> DeleteAsync(Profession entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

    }
}