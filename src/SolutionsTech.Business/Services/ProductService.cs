using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task CreateProduct(Product product)
        {
            product.CreateProduct(product);
            await _productRepository.AddAsync(product);
        }
        public async Task UpdateFormPayment(Product product)
        {
            var productConsulting = await GetById(product.IdProduct);
            await _productRepository.UpdateAsync(productConsulting);
        }
        public async Task DeleteFormPayment(long id)
        {
            await _productRepository.DeleteAsync(id);
        }
        public async Task<Product> GetById(long id) =>
            await _productRepository.GetById(id);

        public async Task<List<Product>> GetListIndex() =>
            await _productRepository.GetListRepository("");
    }
}
