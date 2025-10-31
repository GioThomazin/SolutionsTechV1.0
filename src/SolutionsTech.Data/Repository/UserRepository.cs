using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
	{
        protected readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext applicationDbContext) 
			: base(applicationDbContext)
		{
			_context = applicationDbContext;
		}
		public async Task<User?> GetById(long id)
		{
			return await _context.Users
				.Include(x => x.UserType)
				.FirstOrDefaultAsync(x => x.IdUser == id);
		}
		public async Task<List<User>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);
		public async Task <bool> ExistsByEmailAsync(string email)
		{
			return await _context.Users
				.AnyAsync(u => u.Email.ToLower() == email.ToLower());
		}
	}
}
