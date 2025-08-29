using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsTech.Business.Services
{
	public class SchedulingProductService
	{
		private readonly ISchedulingProductRepository _schedulingProductRepository;
		public SchedulingProductService(ISchedulingProductRepository schedulingProductRepository)
			=> _schedulingProductRepository = schedulingProductRepository;

		public async Task CreateScheduling(SchedulingProduct schedulingProduct)
		{
			schedulingProduct.CreateSchedulingProduct(schedulingProduct);
			await _schedulingProductRepository.AddAsync(schedulingProduct);
		}
		public async Task<List<SchedulingProduct>> GetListScheduling() =>
			await _schedulingProductRepository.GetListScheduling("");
	}
}
