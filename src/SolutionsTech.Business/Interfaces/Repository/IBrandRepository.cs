using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces.Repository
{
   public interface IBrandRepository : IRepositoryBase<Brand>
	{
        Task<List<Brand>> GetListRepository(string properties);
		Task<Brand?> GetById(long id);
        Task<bool> ExistsByNameAsync(string name);
    }
}
