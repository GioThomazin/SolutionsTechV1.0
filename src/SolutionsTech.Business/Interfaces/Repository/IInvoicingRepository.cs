using SolutionsTech.Business.Entities;

namespace SolutionsTech.Business.Interfaces.Repository
{
    public interface IInvoicingRepository : IRepositoryBase<Invoicing>
	{
        Task<List<Invoicing>> GetListRepository(string properties);
	}
}
