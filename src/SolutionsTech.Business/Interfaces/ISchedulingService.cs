
using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
    public interface ISchedulingService
    {
        Task CreateScheduling(Scheduling scheduling);
		Task DeleteScheduling(Scheduling scheduling);
        Task<List<Scheduling>> GetListIndex();

	}
}
