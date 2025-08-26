using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
    public interface ISchedulingProcedureService
    {
		Task CreateProcedure(SchedulingProcedure schedulingProcedure);
		Task<List<SchedulingProcedure>> GetListIndex();
	}
}
