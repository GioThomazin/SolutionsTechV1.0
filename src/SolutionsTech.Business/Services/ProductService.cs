using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public async Task<List<Product>> GetListIndex(string properties) =>
			await _productRepository.GetListRepository(properties);
	}
}
