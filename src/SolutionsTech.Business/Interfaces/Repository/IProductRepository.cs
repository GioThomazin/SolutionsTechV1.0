using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces.Repository
{
	public interface IProductRepository : IRepositoryBase<Product>
	{
		Task<List<Product>> GetListRepository(string properties);
		Task<Product?> GetById(long id);
		Task<Product?> GetByName(string name);
    }
}
