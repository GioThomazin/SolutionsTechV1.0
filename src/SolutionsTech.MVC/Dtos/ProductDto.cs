using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class ProductDto
	{
		public long IdProduct { get; set; }
		public string Name { get; set; }
		public string Size { get; set; }
		public DateTime DtCreate { get; set; } = DateTime.Now;
		public bool Active { get; set; } = true;
		public List<BrandDto> Brand { get; set; }
    }
}
