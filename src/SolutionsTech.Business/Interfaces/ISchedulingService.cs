
using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
	public interface ISchedulingService
	{
		Task CreateScheduling(Scheduling scheduling);
		Task UpdateScheduling(Scheduling scheduling);
		Task DeleteScheduling(long id);
		Task<Scheduling> GetById(long id);
		Task<List<Scheduling>> GetListIndex();
	}
}
