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

		public async Task UpdateTypeProcedure(TypeProcedure typeProcedure)
		{
			var schedulingConsulting = await GetById(typeProcedure.IdTypeProcedure);
			await _typeProcedureRepository.UpdateAsync(schedulingConsulting);
		}
		public async Task DeleteTypeProcedure(long id) =>
			await _typeProcedureRepository.DeleteAsync(id);

        public async Task<TypeProcedure> GetById(long id) => await _typeProcedureRepository.GetById(id);

		public async Task<List<TypeProcedure>> GetListIndex() =>
			await _typeProcedureRepository.GetListRepository("");
    }
}
