using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
	public class SchedulingRepository : RepositoryBase<Scheduling>, ISchedulingRepository
	{
		protected readonly ApplicationDbContext _context;
		public SchedulingRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext) 
		{
			_context = applicationDbContext;
		}
		public async Task<Scheduling?> GetById(long id)
		{
			return await _context.Scheduling
				.Include(x => x.User)
				.Include(x => x.FormPayment)
				.Include(x => x.SchedulingProcedures)
				.Include(x => x.SchedulingProducts)
				.FirstOrDefaultAsync(x => x.IdScheduling == id);
		}

		public async Task<List<Scheduling>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);

	}
}
