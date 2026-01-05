using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class SchedulingProductDto
	{
		public long IdSchedulingProduct { get; set; }
		public long IdScheduling { get; set; }
		public long IdProduct { get; set; }
	}
}