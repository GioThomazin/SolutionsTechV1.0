using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;

namespace SolutionsTech.Business.Services
{
	public class SchedulingProductService : ISchedulingProductService
	{
		private readonly ISchedulingProductRepository _schedulingProductRepository;
		public SchedulingProductService(ISchedulingProductRepository schedulingProductRepository)
			=> _schedulingProductRepository = schedulingProductRepository;

		public async Task CreateSchedulingProduct(SchedulingProduct schedulingProduct)
		{
			schedulingProduct.CreateSchedulingProduct(schedulingProduct);
			await _schedulingProductRepository.AddAsync(schedulingProduct);
		}
		public async Task UpdateSchedulingProduct(SchedulingProduct schedulingProduct)
		{
			var schedulingProductDb = await _schedulingProductRepository.GetByid(schedulingProduct.IdSchedulingProduct);
		}

		public async Task DeleteSchedulingProduct(long id) =>
			await _schedulingProductRepository.DeleteAsync(id);
		public async Task<SchedulingProduct> GetById(long id) =>
	await _schedulingProductRepository.GetByid(id);
		public async Task<List<SchedulingProduct>> GetListIndex() =>
			await _schedulingProductRepository.GetListScheduling("");
	}
}
