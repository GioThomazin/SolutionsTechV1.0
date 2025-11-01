using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository;

public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext) { }

    public async Task<Brand?> GetById(long id) =>
        await GetByIdAsync(id);

    public async Task<Brand?> GetByName(string name) => await FindByAsyncSingle(x => x.Name.ToUpper() == name.Trim().ToUpper());

    public async Task<List<Brand>> GetListRepository(string properties) =>
        await GetAllAsyncWithProperties(properties);
}
