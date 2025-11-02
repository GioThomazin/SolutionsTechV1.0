using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Business.Validations;

namespace SolutionsTech.Business.Services;

public class BrandService : BaseService, IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository, INotificador notificador) : base(notificador) => _brandRepository = brandRepository;

    public async Task CreateBrand(Brand brand)
    {
        if (!ExecutarValidacao(new BrandValidation(), brand))
            return;

        var existingBrand = await _brandRepository.GetByName(brand.Name);

        if (existingBrand is not null)
        {
            Notificar($"Já existe uma marca com o mesmo nome '{brand.Name}'");
            return;
        }

        await _brandRepository.AddAsync(brand);
        return;
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
    public async Task<Brand> GetById(long id) => await _brandRepository.GetById(id);

    public async Task<List<Brand>> GetListIndex() =>
            await _brandRepository.GetListRepository("");

}
