using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services
{
	public class BrandService : IBrandService
	{
		private readonly IBrandRepository _brandRepository;
		public BrandService(IBrandRepository brandRepository) => _brandRepository = brandRepository;
		
		public async Task CreateBrand(Brand brand)
		{
			brand.CreateBrand(brand);
			await _brandRepository.AddAsync(brand);
		}

		public async Task<List<Brand>> GetListIndex() =>
				await _brandRepository.GetListRepository("");
	}
}
