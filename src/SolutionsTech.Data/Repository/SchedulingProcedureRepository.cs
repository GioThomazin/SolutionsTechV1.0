using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
    public class SchedulingProcedureRepository : RepositoryBase<SchedulingProcedure>, ISchedulingProcedureRepository
    {
        private readonly RepositoryBase<SchedulingProcedure> repository;
        public SchedulingProcedureRepository(ApplicationDbContext applicationDbContext)
    : base(applicationDbContext) { }

        public async Task<SchedulingProcedure> GetByid(long id) =>
            await repository.GetByIdAsync(id);
        public async Task<List<SchedulingProcedure>> GetListRepository(string properties) =>
            await GetAllAsyncWithProperties(properties);
    }
}
