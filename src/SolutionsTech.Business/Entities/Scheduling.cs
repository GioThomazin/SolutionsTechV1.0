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

        [ForeignKey("IdUser")]
        public virtual User User { get; set; }


        public long IdFormPayment { get; set; }

        [ForeignKey("IdFormPayment")]
        public virtual FormPayment FormPayment { get; set; }


        [NotMapped]
        [ForeignKey("IdScheduling")]
        public virtual SchedulingProcedure SchedulingProcedure { get; set; }

        [NotMapped]
        [ForeignKey("IdScheduling")]
        public virtual SchedulingProduct SchedulingProduct { get; set; }
    }
}

