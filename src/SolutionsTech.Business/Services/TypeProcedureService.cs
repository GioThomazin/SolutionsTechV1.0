using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services
{
  public class TypeProcedureService : ITypeProcedureService
    {
        private readonly ITypeProcedureRepository _typeProcedureRepository;

		public TypeProcedureService(ITypeProcedureRepository typeProcedureRepository) 
			=> _typeProcedureRepository = typeProcedureRepository;

		public async Task CreateTypeProcedure(TypeProcedure typeProcedure)
		{
			typeProcedure.CreateTypeProcedure(typeProcedure);
			await _typeProcedureRepository.AddAsync(typeProcedure);
		}
		public async Task<List<TypeProcedure>> GetListIndex() =>
			await _typeProcedureRepository.GetListRepository("");
	}
}
