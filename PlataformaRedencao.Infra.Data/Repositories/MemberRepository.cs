using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de persistência para <see cref="Member"/>.
    /// </summary>
    public class MemberRepository : IMemberRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="MemberRepository"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public MemberRepository(PlataformaRedencaoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém um Member pelo identificador.
        /// </summary>
        /// <param name="id">Identificador do Member (pode ser nulo).</param>
        /// <returns>Uma tarefa que contém o Member encontrado ou <c>null</c> se não encontrado.</returns>
        public async Task<Member?> GetByIdAsync(int? id)
            => await _context.Members
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

        /// <summary>
        /// Obtém os Members de uma igreja.
        /// </summary>
        /// <param name="churchId">Identificador da igreja.</param>
        /// <returns>Uma tarefa que contém a lista de Members da igreja informada.</returns>
        public async Task<IReadOnlyList<Member>> GetByChurchAsync(int churchId)
            => await _context.Members
                .AsNoTracking()
                .Where(m => m.ChurchId == churchId)
                .ToListAsync();

        /// <summary>
        /// Obtém todos os Members.
        /// </summary>
        /// <returns>Uma tarefa que contém uma coleção somente-leitura com todos os Members.</returns>
        public async Task<IReadOnlyCollection<Member?>> GetAllAsync()
            => await _context.Members
                .AsNoTracking()
                .ToListAsync();

        /// <summary>
        /// Adiciona um novo Member e persiste no banco.
        /// </summary>
        /// <param name="entidade">Entidade <see cref="Member"/> a ser adicionada.</param>
        /// <returns>A entidade adicionada com possíveis valores gerados (ex.: Id).</returns>
        public async Task<Member> AddAsync(Member entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Atualiza um Member existente e persiste as alterações.
        /// </summary>
        /// <param name="entidade">Entidade <see cref="Member"/> a ser atualizada.</param>
        /// <returns>A entidade atualizada.</returns>
        public async Task<Member> UpdateAsync(Member entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Remove um Member e persiste a exclusão.
        /// </summary>
        /// <param name="entidade">Entidade <see cref="Member"/> a ser removida.</param>
        /// <returns>A entidade removida.</returns>
        public async Task<Member> DeleteAsync(Member entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Obtém Members ativos de uma igreja.
        /// </summary>
        /// <param name="churchId">Identificador da igreja.</param>
        /// <returns>Uma tarefa que contém a lista de Members ativos da igreja informada.</returns>
        public async Task<IReadOnlyList<Member>> GetActivesByChurchAsync(int churchId)
            => await _context.Members
                .AsNoTracking()
                .Where(m => m.ChurchId == churchId && m.Status == MemberStatus.Active)
                .ToListAsync();

        /// <summary>
        /// Obtém Members inativos de uma igreja.
        /// </summary>
        /// <param name="churchId">Identificador da igreja.</param>
        /// <returns>Uma tarefa que contém a lista de Members inativos da igreja informada.</returns>
        public async Task<IReadOnlyList<Member?>> GetInactivesByChurchAsync(int churchId)
            => await _context.Members
                .AsNoTracking()
                .Where(m => m.ChurchId == churchId && m.Status == MemberStatus.Suspended)
                .ToListAsync();

        /// <summary>
        /// Obtém um Member pela combinação CPF e igreja.
        /// </summary>
        /// <param name="cpf">CPF do Member.</param>
        /// <param name="churchId">Identificador da igreja.</param>
        /// <returns>A entidade encontrada ou <c>null</c> caso não exista.</returns>
        public async Task<Member?> GetByCpfAsync(string cpf, int churchId)
            => await _context.Members
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Cpf! == cpf && m.ChurchId == churchId);

        /// <summary>
        /// Obtém um Member pelo e-mail e igreja.
        /// </summary>
        /// <param name="email">E-mail do Member.</param>
        /// <param name="churchId">Identificador da igreja.</param>
        /// <returns>A entidade encontrada ou <c>null</c> caso não exista.</returns>
        public async Task<Member?> GetByEmailAsync(string email, int churchId)
            => await _context.Members
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Contact!.EmailAddress!.Address == email && m.ChurchId == churchId);


    }
}