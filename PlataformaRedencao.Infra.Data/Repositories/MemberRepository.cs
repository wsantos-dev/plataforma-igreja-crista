using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repository for persistence operations on <see cref="Member"/> entities.
    /// </summary>
    public class MemberRepository : IMemberRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="MemberRepository"/>.
        /// </summary>
        /// <param name="context">Database context.</param>
        public MemberRepository(PlataformaRedencaoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a member by id.
        /// </summary>
        /// <param name="id">Member id (nullable).</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        public async Task<Member?> GetByIdAsync(int? id)
            => await _context.Members
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

        /// <summary>
        /// Gets members of a church.
        /// </summary>
        /// <param name="churchId">Church id.</param>
        /// <returns>List of members of the given church.</returns>
        public async Task<IReadOnlyList<Member>> GetByChurchAsync(int churchId)
            => await _context.Members
                .AsNoTracking()
                .Where(m => m.ChurchId == churchId)
                .ToListAsync();

        /// <summary>
        /// Gets all members.
        /// </summary>
        /// <returns>A read-only collection of all members.</returns>
        public async Task<IReadOnlyCollection<Member?>> GetAllAsync()
            => await _context.Members
                .AsNoTracking()
                .ToListAsync();

        /// <summary>
        /// Adds a new member and persists it.
        /// </summary>
        /// <param name="entidade">Member entity to add.</param>
        /// <returns>The added entity with generated values (e.g. Id).</returns>
        public async Task<Member> AddAsync(Member entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Updates an existing member and persists changes.
        /// </summary>
        /// <param name="entidade">Member entity to update.</param>
        /// <returns>The updated entity.</returns>
        public async Task<Member> UpdateAsync(Member entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Removes a member and persists the deletion.
        /// </summary>
        /// <param name="entidade">Member entity to remove.</param>
        /// <returns>The removed entity.</returns>
        public async Task<Member> DeleteAsync(Member entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        /// <summary>
        /// Gets active members of a church.
        /// </summary>
        /// <param name="churchId">Church id.</param>
        /// <returns>List of active members of the given church.</returns>
        public async Task<IReadOnlyList<Member>> GetActivesByChurchAsync(int churchId)
            => await _context.Members
                .AsNoTracking()
                .Where(m => m.ChurchId == churchId && m.Status == MemberStatus.Active)
                .ToListAsync();

        /// <summary>
        /// Gets inactive members of a church.
        /// </summary>
        /// <param name="churchId">Church id.</param>
        /// <returns>List of inactive members of the given church.</returns>
        public async Task<IReadOnlyList<Member?>> GetInactivesByChurchAsync(int churchId)
            => await _context.Members
                .AsNoTracking()
                .Where(m => m.ChurchId == churchId && m.Status == MemberStatus.Suspended)
                .ToListAsync();

        /// <summary>
        /// Gets a member by CPF and church.
        /// </summary>
        /// <param name="cpf">Member CPF.</param>
        /// <param name="churchId">Church id.</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        public async Task<Member?> GetByCpfAsync(string cpf, int churchId)
            => await _context.Members
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Cpf! == cpf && m.ChurchId == churchId);

        /// <summary>
        /// Gets a member by email and church.
        /// </summary>
        /// <param name="email">Member email.</param>
        /// <param name="churchId">Church id.</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        public async Task<Member?> GetByEmailAsync(string email, int churchId)
            => await _context.Members
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Contact!.EmailAddress!.Address == email && m.ChurchId == churchId);


    }
}