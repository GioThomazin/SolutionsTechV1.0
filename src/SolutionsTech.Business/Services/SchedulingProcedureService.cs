using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services
{
  public class SchedulingProcedureService : ISchedulingProcedureService
    {
        private readonly ISchedulingProcedureRepository _schedulingProcedureRepository;
	    public SchedulingProcedureService(ISchedulingProcedureRepository schedulingProcedureRepository) =>
			_schedulingProcedureRepository = schedulingProcedureRepository;

		public async Task CreateProcedure(SchedulingProcedure schedulingProcedure)
		{
			await _schedulingProcedureRepository.AddAsync(schedulingProcedure);
		}
		public async Task<List<SchedulingProcedure>> GetListIndex() =>
			await _schedulingProcedureRepository.GetListRepository("");
	}
}
