using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{
	public class Brand
	{
		[Key]
		public long IdBrand { get; set; }
		public string Name { get; set; } = string.Empty;
		public DateTime DtCreate { get; set; } = DateTime.Now;
		public DateTime? DtDesativation { get; set; }
		public bool Active { get; set; } = true;
		public void CreateBrand(Brand brand)
		{

		}
	}
}
