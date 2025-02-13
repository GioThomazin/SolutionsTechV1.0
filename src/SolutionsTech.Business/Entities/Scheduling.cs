using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsTech.Business.Entity
{
    public class Scheduling
    {
        [Key]
        public long IdScheduling { get; set; }
        public string Name { get; set; }
        public DateTime DtCreate { get; set; } = DateTime.Now;
		public DateTime? DtDesativation { get; set; }
		public decimal TotalValue { get; set; }
        public string Observation { get; set; } = string.Empty;

		[ForeignKey("IdUser")]
		public long IdUser { get; set; }

		[ForeignKey("IdFormPayment")]
		public long IdFormPayment { get; set; }
	}
}
