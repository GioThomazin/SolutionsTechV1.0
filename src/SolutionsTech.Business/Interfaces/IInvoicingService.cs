using SolutionsTech.Business.Entities;

namespace SolutionsTech.Business.Interfaces
{
    public interface IInvoicingService
    {
		Task CreateInvoicing(Invoicing invoicing);
		Task<List<Invoicing>> GetListIndex();
	}
}
