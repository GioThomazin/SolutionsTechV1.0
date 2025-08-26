using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SolutionsTech.Business.Entity
{
    public class Product
    {
        [Key]
        public long IdProduct { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public DateTime DtCreate { get; set; } = DateTime.Now;
		public DateTime? DtDesativation { get; set; }
		public bool Active { get; set; } = true;

        [ForeignKey("IdBrand")]
        public long IdBrand { get; set; }

		[NotMapped]
		public virtual Brand Brand { get; set; }
		public void CreateProduct(Product product)
		{
		}
	}
}
