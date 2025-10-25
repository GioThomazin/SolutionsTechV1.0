using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
    public class FormPaymentRepository : RepositoryBase<FormPayment>, IFormPaymentRepository
	{
        public FormPaymentRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext){ }

		public async Task<FormPayment>? GetById(long id) =>
			await GetByIdAsync(id);
        public async Task<List<FormPayment>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);
	}
}
