
using SolutionsTech.Business.Entity;
using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
    public class SchedulingProcedureDto
    {
        public long IdTypeProcedure { get; set; }
        public TypeProcedure TypeProcedure { get; set; }
    }
}
