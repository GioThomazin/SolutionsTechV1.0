using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
	public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
	{
		public BrandRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext) { }
		public async Task<List<Brand>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);
	}
}
