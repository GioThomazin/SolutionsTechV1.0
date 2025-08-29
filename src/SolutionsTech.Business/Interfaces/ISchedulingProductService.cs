using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
    public interface ISchedulingProductService
    {
		Task CreateSchedulingProduct(SchedulingProduct schedulingProduct);
		Task<List<SchedulingProduct>> GetListByScheduling();
	}
}
