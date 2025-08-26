using SolutionsTech.Business.Entities;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
    public class InvoicingRepository : RepositoryBase<Invoicing>, IInvoicingRepository
	{
		public InvoicingRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext) { }
		public async Task<List<Invoicing>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);	
	}
}
