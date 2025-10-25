using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly ISchedulingRepository _schedulingRepository;

        public SchedulingService(ISchedulingRepository schedulingRepository) => _schedulingRepository = schedulingRepository;

        public async Task CreateScheduling(Scheduling scheduling)
        {
            scheduling.CreateScheduling(scheduling);
            await _schedulingRepository.AddAsync(scheduling);
        }

        public async Task UpdateScheduling(Scheduling scheduling)
        {
            var schedulingConsulting = await GetById(scheduling.IdScheduling);

            await _schedulingRepository.UpdateAsync(schedulingConsulting);
        }

        public async Task DeleteScheduling(long id) =>
            await _schedulingRepository.DeleteAsync(id);

        public async Task<Scheduling> GetById(long id) =>
            await _schedulingRepository.GetById(id);

        public async Task<List<Scheduling>> GetListIndex()
        {
            return await _schedulingRepository.GetListRepository(
                "User,FormPayment,SchedulingProcedures,SchedulingProcedures.TypeProcedure,SchedulingProducts"
            );
        }
    }
}
