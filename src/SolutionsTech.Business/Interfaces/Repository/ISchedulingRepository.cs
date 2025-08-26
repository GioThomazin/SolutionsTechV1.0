using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces.Repository
{
    public interface ISchedulingRepository : IRepositoryBase<Scheduling>
    {
        Task<List<Scheduling>> GetListRepository(string properties);
    }
}
