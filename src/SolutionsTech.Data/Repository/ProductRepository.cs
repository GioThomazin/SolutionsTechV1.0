using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
	public class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext) { }
		public async Task<List<Product>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);
	}
}
