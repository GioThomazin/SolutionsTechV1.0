using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository) => _brandRepository = brandRepository;

    public async Task<string> CreateBrand(Brand brand)
    {
        var existingBrand = await _brandRepository.GetByName(brand.Name);

        if (existingBrand is not null)
        {
            return $"Já existe uma marca com o mesmo nome '{brand.Name}'";
        }

        await _brandRepository.AddAsync(brand);

        return string.Empty;
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
