using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class ProductDto
	{
		public long IdProduct { get; set; }
		public string Name { get; set; }
		public string Size { get; set; }
		public DateTime DtCreate { get; set; }
		public bool Active { get; set; }
		public List<BrandDto> Brand { get; set; }
    }
}
