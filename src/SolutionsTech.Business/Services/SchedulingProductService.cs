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
		public async Task<List<SchedulingProduct>> GetListByScheduling() =>
			await _schedulingProductRepository.GetListScheduling("");
	}
}
