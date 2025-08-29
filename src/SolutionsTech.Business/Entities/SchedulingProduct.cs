using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{
    public class SchedulingProduct
    {
        [Key]
        public long IdSchedulingProduct { get; set; }
        public long IdScheduling { get; set; }
        public long IdProduct { get; set; }
        
        public void CreateSchedulingProduct(SchedulingProduct schedulingProductValores)
		{
		}
	}
}
