using SolutionsTech.Business.Entities;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services
{
	public class InvoicingService : IInvoicingService
	{
		private readonly IInvoicingRepository _invoicingRepository;
		public InvoicingService(IInvoicingRepository invoicingRepository) =>
			_invoicingRepository = invoicingRepository;
		
		public async Task CreateInvoicing(Invoicing invoicing)
		{
			invoicing.CreateInvoicing(invoicing);
			await _invoicingRepository.AddAsync(invoicing);
		}
		public async Task<List<Invoicing>> GetListIndex() =>
			await _invoicingRepository.GetListRepository("");
	}
}
