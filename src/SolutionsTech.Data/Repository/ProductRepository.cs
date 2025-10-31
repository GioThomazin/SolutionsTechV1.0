using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<Product?> GetById(long id) =>
            await GetByIdAsync(id);

        public async Task<List<Product>> GetListRepository(string properties) =>
            await GetAllAsyncWithProperties(properties);

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Product
                .AnyAsync(p => p.Name.ToLower() == name.ToLower());
        }
    }
}
