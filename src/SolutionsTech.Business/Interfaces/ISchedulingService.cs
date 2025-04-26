
using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
    public interface ISchedulingService
    {
        Task CriarAgendamento(Scheduling scheduling);
        Task<List<Scheduling>> GetListIndex();
    }
}
