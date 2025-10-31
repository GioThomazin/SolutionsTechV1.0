using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
  public class TypeProcedureRepository : RepositoryBase<TypeProcedure>, ITypeProcedureRepository
	{
		public TypeProcedureRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext) { }
		public async Task<List<TypeProcedure>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);
		
		public async Task<List<TypeProcedure>> GetByIdsAsync(List<long> ids) =>
			await FindByAsyncList(tp => ids.Contains(tp.IdTypeProcedure));
    }
}
