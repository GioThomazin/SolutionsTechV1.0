using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class SchedulingProductDto
	{
		public long IdSchedulingProduct { get; set; }
		public SchedulingDto Scheduling { get; set; }
		public ProductDto Product { get; set; }
	}
}
