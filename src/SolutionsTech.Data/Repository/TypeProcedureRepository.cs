using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;

namespace SolutionsTech.Data.Repository
{
	public class TypeProcedureRepository : RepositoryBase<TypeProcedure>, ITypeProcedureRepository
	{
		private readonly RepositoryBase<TypeProcedure> repository;
		public TypeProcedureRepository(ApplicationDbContext context) : base(context)
		{
			repository = new RepositoryBase<TypeProcedure>(context);
		}
		public async Task<List<TypeProcedure>> GetListRepository(string properties) =>
			await GetAllAsyncWithProperties(properties);
		public async Task<TypeProcedure?> GetById(long id) =>
			await repository.GetByIdAsync(id);

		public async Task<List<TypeProcedure>> GetByIdsAsync(List<long> ids) =>
			await FindByAsyncList(tp => ids.Contains(tp.IdTypeProcedure));
	}
}
