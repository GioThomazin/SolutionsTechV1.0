using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
    public class SchedulingProductRepository : RepositoryBase<SchedulingProduct>, ISchedulingProductRepository
	{
		public SchedulingProductRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext) { }

		public async Task<SchedulingProduct> GetByid(long id) =>
			await GetByIdAsync(id);
		public async Task<List<SchedulingProduct>> GetListScheduling(string properties) =>
			await GetAllAsyncWithProperties(properties);
	}
}
