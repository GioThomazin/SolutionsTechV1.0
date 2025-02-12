namespace SolutionsTech.MVC.Dto
{
	public class BrandDto
	{
		public long IdBrand { get; set; }
		public string Name { get; set; }
        public string? Size { get; set; }
        public DateTime DtCreate { get; set; }
		public bool Active { get; set; }
	}
}
