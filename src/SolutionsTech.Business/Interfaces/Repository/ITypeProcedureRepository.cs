using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces.Repository
{
    public interface ITypeProcedureRepository : IRepositoryBase<TypeProcedure>
	{
		Task<List<TypeProcedure>> GetListRepository(string properties);
		Task<List<TypeProcedure>> GetByIdsAsync(List<long> ids);
		Task<TypeProcedure?> GetById(long id);
	}
}
