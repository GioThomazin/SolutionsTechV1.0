using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
    public class FormPaymentRepository : RepositoryBase<FormPayment>, IFormPaymentRepository
    {
        private readonly ApplicationDbContext _context;
        public FormPaymentRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<FormPayment>? GetById(long id) =>
            await GetByIdAsync(id);
        public async Task<List<FormPayment>> GetListRepository(string properties) =>
            await GetAllAsyncWithProperties(properties);
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.FormPayment
                .AnyAsync(fp => fp.Name.ToLower() == name.ToLower());
        }
    }
}
