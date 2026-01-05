	using SolutionsTech.Business.Entity;
	using SolutionsTech.Business.Interfaces;
	using SolutionsTech.Business.Interfaces.Repository;
	using SolutionsTech.Business.Validations;

	namespace SolutionsTech.Business.Services
	{
		public class ProductService : BaseService, IProductService
		{
			private readonly IProductRepository _productRepository;
			public ProductService(IProductRepository productRepository, INotificador notificador) : base(notificador) => _productRepository = productRepository;

			public async Task CreateProduct(Product product)
			{

				if (!ExecutarValidacao(new ProductValidation(), product))
					return;

				var existsProduct = await _productRepository.GetByName(product.Name);

				if (existsProduct is not null)
				{
					Notificar($"Já existe um produto cadastrado com o nome {product.Name}.");
					return;
				}
				await _productRepository.AddAsync(product);
				return;

			}
			public async Task UpdateProduct(Product product)
			{
				var productConsulting = await GetById(product.IdProduct);
				await _productRepository.UpdateAsync(productConsulting);
			}
			public async Task DeleteProduct(long id)
			{
				await _productRepository.DeleteAsync(id);
			}
			public async Task<Product> GetById(long id) =>
				await _productRepository.GetById(id);

			public async Task<List<Product>> GetListIndex() =>
				await _productRepository.GetListRepository("");
		}
	}
