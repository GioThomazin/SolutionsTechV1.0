using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces.Repository
{
    public interface IFormPaymentRepository : IRepositoryBase<FormPayment>
	{
        Task<List<FormPayment>> GetListRepository(string properties);
	}
}
