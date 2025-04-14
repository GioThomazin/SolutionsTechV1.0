using SolutionsTech.Business.Entity;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Dtos.ViewModel
{
	public class SchedulingView
	{
		public List<UserDto> Users { get; set; }
		public List<SchedulingDto> Schedulings { get; set; }
		public List<FormPaymentDto> FormPayments { get; set; }
		public List<TypeProcedureDto> TypeProcedures { get; set; }
		public List<SchedulingProcedureDto> SchedulingProcedures { get; set; }
		public List<SchedulingProductDto> SchedulingProducts { get; set; }
		public SchedulingDto Scheduling { get; set; }
	}
}
