using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces.Repository
{
    public interface ISchedulingProductRepository : IRepositoryBase<SchedulingProduct>
	{
		Task<List<SchedulingProduct>> GetListScheduling(string idScheduling);
		Task<SchedulingProduct> GetByid(long id);
	}
}
