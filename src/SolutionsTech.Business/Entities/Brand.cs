using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{

	public class Brand
	{
		[Key]
		public long IdBrand { get; set; }
		public string Name { get; set; }
        public string? Size { get; set; }
        public DateTime DtCreate { get; set; } = DateTime .Now;
		public bool Active { get; set; }

	}
}
