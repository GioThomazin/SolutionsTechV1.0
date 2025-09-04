using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces.Repository
{
    public interface ITypeProcedureRepository : IRepositoryBase<TypeProcedure>
	{
		Task<List<TypeProcedure>> GetListRepository(string properties);
	}
}
