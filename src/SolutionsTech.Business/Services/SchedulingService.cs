using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly  ISchedulingRepository _schedulingRepository;

        public SchedulingService(ISchedulingRepository schedulingRepository) => _schedulingRepository = schedulingRepository;

        public async Task CriarAgendamento(Scheduling scheduling)
        {
            scheduling.CriarAgendamento(scheduling);
            await _schedulingRepository.AddAsync(scheduling);
        }


        public async Task<List<Scheduling>> GetListIndex() =>
            await _schedulingRepository.GetListRepository("User,FormPayment,SchedulingProcedures,SchedulingProcedures.TypeProcedure,SchedulingProducts");
    }
}
