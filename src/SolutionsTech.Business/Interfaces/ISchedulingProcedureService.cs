using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
    public interface ISchedulingProcedureService
    {
		Task CreateProcedure(SchedulingProcedure schedulingProcedure);
		Task UpdateSchedulingProcedure(SchedulingProcedure schedulingProcedure);
        Task DeleteSchedulingProcedure(long id);
        Task<SchedulingProcedure> GetById(long id);
        Task<List<SchedulingProcedure>> GetListIndex();
	}
}
