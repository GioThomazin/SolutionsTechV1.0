using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly IRepositoryBase<Scheduling> _repo;

        public SchedulingRepository(IRepositoryBase<Scheduling> repo) => _repo = repo;

        public async Task SalvarAgendamentoRepository(Scheduling scheduling) => await _repo.AddAsync(scheduling);
    }
}
