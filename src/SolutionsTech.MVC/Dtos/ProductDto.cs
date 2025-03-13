namespace SolutionsTech.MVC.Dto
{
	public class ProductDto
	{
		public long IdProduct { get; set; }
		public string Name { get; set; }
		public string Size { get; set; }
		public DateTime DtCreate { get; set; } = DateTime.Now;
		public bool Active { get; set; } = true;
		public long IdBrand { get; set; }
		public BrandDto? Brand { get; set; }
		public IEnumerable<BrandDto> Brands { get; set; } = new List<BrandDto>();
	}
}
