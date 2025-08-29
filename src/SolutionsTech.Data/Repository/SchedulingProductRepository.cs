using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsTech.Data.Repository
{
    public class SchedulingProductRepository : RepositoryBase<SchedulingProduct>, ISchedulingProductRepository
	{
		public SchedulingProductRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext) { }

		public async Task<List<SchedulingProduct>> GetListScheduling(string properties) =>
			await GetAllAsyncWithProperties(properties);
	}
}
