using SolutionsTech.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsTech.Business.Interfaces
{
public interface IProductService
    {
		Task CreateProduct(Product product);
		Task<List<Product>> GetListIndex(string properties);
	}
}
