using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
	public class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext) { }
		public async Task<Product?> GetById(long id) =>
			await GetByIdAsync(id);

		public async Task<Product?> GetByName(string name) => await FindByAsyncSingle(x => x.Name.ToUpper() == name.Trim().ToUpper());

		public async Task<List<Product>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);
	}
}
