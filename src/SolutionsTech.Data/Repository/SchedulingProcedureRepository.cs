using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Business.Services;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
  public class SchedulingProcedureRepository : RepositoryBase<SchedulingProcedure>, ISchedulingProcedureRepository
	{
		public SchedulingProcedureRepository(ApplicationDbContext applicationDbContext)
	: base(applicationDbContext) { }

		public async Task<List<SchedulingProcedure>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);
	}
}
