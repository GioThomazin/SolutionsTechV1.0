using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces.Repository
{
    public interface IFormPaymentRepository : IRepositoryBase<FormPayment>
	{
        Task<List<FormPayment>> GetListRepository(string properties);
        Task<FormPayment?> GetByName(string name);
		Task<FormPayment?> GetById(long id);
    }
}
