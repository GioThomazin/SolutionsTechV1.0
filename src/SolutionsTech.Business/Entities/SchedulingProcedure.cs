using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsTech.Business.Entity
{
    public class SchedulingProcedure
    {
        [Key]
        public long IdSchedulingProcedure { get; set; }
        public long IdScheduling { get; set; }
        public long IdTypeProcedure { get; set; }

        [ForeignKey("IdTypeProcedure")]
        public virtual TypeProcedure TypeProcedure { get; set; }
    }
}
