using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{
    public class SchedulingProcedure
    {
        [Key]
        public long IdSchedulingProcedure { get; set; }
        public long IdScheduling { get; set; }
        public long IdTypeProcedure { get; set; }
    }
}
