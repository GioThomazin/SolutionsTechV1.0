using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
   public interface IBrandService
    {
		Task<string> CreateBrand(Brand brand);
		Task UpdateBrand(Brand brand);
		Task DeleteBrand(long id);
		Task<Brand> GetById(long id);
        Task<List<Brand>> GetListIndex();
    }
}
