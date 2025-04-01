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
	}
}
