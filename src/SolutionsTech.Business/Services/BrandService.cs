using Microsoft.EntityFrameworkCore;
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
		
		public async Task UpdateBrand(Brand brand)
		{
			var brandConsulting = await GetById(brand.IdBrand);
			await _brandRepository.UpdateAsync(brandConsulting);
        }

		public async Task DeleteBrand(long id)
		{
			await _brandRepository.DeleteAsync(id);
        }
            public async Task<Brand> GetById(long id) =>
				await _brandRepository.GetById(id);
        public async Task<List<Brand>> GetListIndex() =>
				await _brandRepository.GetListRepository("");
    }
}
