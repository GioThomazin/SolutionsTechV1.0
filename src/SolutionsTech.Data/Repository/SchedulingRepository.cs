using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
    public class SchedulingRepository : RepositoryBase<Scheduling>, ISchedulingRepository
    {
        public SchedulingRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext) { }

        public async Task<List<Scheduling>> GetListRepository(string properties) =>
            await GetAllAsyncWithProperties(properties);
    }
}
