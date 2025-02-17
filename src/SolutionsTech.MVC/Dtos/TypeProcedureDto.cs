using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class TypeProcedureDto
	{
		public long IdTypeProcedure { get; set; }
		public string Name { get; set; }
		public decimal Value { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
