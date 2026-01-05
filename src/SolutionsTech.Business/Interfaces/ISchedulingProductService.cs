using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
    public interface ISchedulingProductService
    {
		Task CreateSchedulingProduct(SchedulingProduct schedulingProduct);
		Task UpdateSchedulingProduct(SchedulingProduct schedulingProduct);
		Task DeleteSchedulingProduct(long id);
		Task<SchedulingProduct> GetById(long id);
		Task<List<SchedulingProduct>> GetListIndex();
	}
}
