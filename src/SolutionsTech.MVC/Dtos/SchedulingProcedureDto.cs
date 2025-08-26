
using SolutionsTech.Business.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsTech.MVC.Dto
{
	public class SchedulingProcedureDto
	{
		public long IdSchedulingProcedure { get; set; }
		public long IdScheduling { get; set; }
		public long IdTypeProcedure { get; set; }

		[ForeignKey("IdTypeProcedure")]
		public virtual TypeProcedure TypeProcedure { get; set; }
	}
}
