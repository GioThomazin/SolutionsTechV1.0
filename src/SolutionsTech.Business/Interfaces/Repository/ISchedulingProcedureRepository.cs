using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces.Repository
{
   public interface ISchedulingProcedureRepository : IRepositoryBase<SchedulingProcedure>
	{
		Task<List<SchedulingProcedure>> GetListRepository(string properties);
		Task<SchedulingProcedure> GetByid(long id);
    }
}
