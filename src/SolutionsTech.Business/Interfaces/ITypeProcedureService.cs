using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Interfaces
{
    public interface ITypeProcedureService
    {
        Task CreateTypeProcedure(TypeProcedure typeProcedure);
		Task UpdateTypeProcedure(TypeProcedure typeProcedure);
		Task DeleteTypeProcedure(long id);
        Task<TypeProcedure> GetById(long id);
		Task<List<TypeProcedure>> GetListIndex();
    }
}