using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
public interface IProductService
    {
		Task CreateProduct(Product product);
		Task UpdateProduct(Product product);
		Task DeleteProduct(long id);
		Task <Product> GetById(long id);
		Task<List<Product>> GetListIndex();
    }
}
