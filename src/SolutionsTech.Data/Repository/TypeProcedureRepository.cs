using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
    public class TypeProcedureRepository : RepositoryBase<TypeProcedure>, ITypeProcedureRepository
    {
        private readonly ApplicationDbContext _context;
        public TypeProcedureRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<List<TypeProcedure>> GetListRepository(string properties) =>
            await GetAllAsyncWithProperties(properties);

        public async Task<List<TypeProcedure>> GetByIdsAsync(List<long> ids) =>
            await FindByAsyncList(tp => ids.Contains(tp.IdTypeProcedure));
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.TypeProcedure
                .AnyAsync(tp => tp.Name.ToLower() == name.ToLower());
        }
    }
}
