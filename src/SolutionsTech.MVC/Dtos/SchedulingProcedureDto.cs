
using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class SchedulingProcedureDto
	{
		public long IdSchedulingProcedure { get; set; }
		public SchedulingDto Scheduling { get; set; }
		public TypeProcedureDto TypeProcedure { get; set; }
	}
}
