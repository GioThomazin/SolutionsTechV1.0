using SolutionsTech.Business.Entity;
using System;

namespace SolutionsTech.Business.Interfaces
{
    public interface ITypeProcedureService
    {
        Task CreateTypeProcedure(TypeProcedure typeProcedure);
		Task<List<TypeProcedure>> GetListIndex();
        Task<List<TypeProcedure>> GetByIdsAsync(List<long> ids);
    }
}
