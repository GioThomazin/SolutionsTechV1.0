using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
	public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
        {
                _context = applicationDbContext;
        }
		
		public async Task<Brand?> GetById(long id) =>
			await GetByIdAsync(id);
		
		public async Task<List<Brand>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Brand
                .AnyAsync(b => b.Name.ToLower() == name.ToLower());
        }
    }
}
