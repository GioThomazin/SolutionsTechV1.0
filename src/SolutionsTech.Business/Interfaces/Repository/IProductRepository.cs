using SolutionsTech.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsTech.Business.Interfaces.Repository
{
	public interface IProductRepository : IRepositoryBase<Product>
	{
		Task<List<Product>> GetListRepository(string properties);
	}
}
