using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
    public interface ITypeProcedureService
    {
        Task CreateTypeProcedure(TypeProcedure typeProcedure);
		Task<List<TypeProcedure>> GetListIndex();
	}
}
