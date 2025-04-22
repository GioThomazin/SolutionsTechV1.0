using SolutionsTech.Business.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsTech.Business.Entity
{
    public class Scheduling
    {
        [Key]
        public long IdScheduling { get; set; }

        public DateTime DtCreate { get; set; } = DateTime.Now;
        public DateTime? DtDesativation { get; set; }
        public decimal TotalValue { get; set; }
        public string? Observation { get; set; } = string.Empty;
        public long IdUser { get; set; }
		public long IdFormPayment { get; set; }

		[ForeignKey("IdUser")]
        public virtual User User { get; set; }

        [ForeignKey("IdFormPayment")]
        public virtual FormPayment FormPayment { get; set; }

        [ForeignKey("IdScheduling")]
        public virtual List<SchedulingProcedure> SchedulingProcedures { get; set; }

        [ForeignKey("IdScheduling")]
        public virtual List<SchedulingProduct> SchedulingProducts { get; set; }
    }
}


