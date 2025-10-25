using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
	public class SchedulingRepository : RepositoryBase<Scheduling>, ISchedulingRepository
	{
		private readonly RepositoryBase<Scheduling> repository;
		public SchedulingRepository(ApplicationDbContext context) : base(context)
		{
			repository = new RepositoryBase<Scheduling>(context);
		}

		public async Task<Scheduling?> GetById(long id) =>
			await repository.GetByIdAsync(id);

		public async Task<List<Scheduling>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);
		public async Task Update(Scheduling scheduling) => await repository.UpdateAsync(scheduling);
	}
}