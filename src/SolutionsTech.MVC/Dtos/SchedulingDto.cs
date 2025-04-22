using SolutionsTech.Business.Entity;

namespace SolutionsTech.MVC.Dto
{
    public class SchedulingDto
    {
        public long IdScheduling { get; set; }
        public DateTime DtCreate { get; set; } = DateTime.Now;
        public decimal TotalValue { get; set; }
        public string? Observation { get; set; }
        public long IdUser { get; set; }
        public long IdFormPayment { get; set; }
        public long IdTypeProcedure { get; set; }
		public long IdSchedulingProcedure { get; set; }
		public long IdSchedulingProduct { get; set; }
		public UserDto? User { get; set; }

        public List<UserDto?> Users { get; set; } = new List<UserDto?>();
        public FormPaymentDto? FormPayment { get; set; }
        public List<FormPaymentDto?> FormPayments { get; set; } = new List<FormPaymentDto?>();
        public TypeProcedureDto? TypeProcedure { get; set; }
        public List<TypeProcedureDto?> TypeProcedures { get; set; } = new List<TypeProcedureDto?>();

		public SchedulingProcedureDto? SchedulingProcedure { get; set; }
		public List<SchedulingProcedureDto?> SchedulingProcedures { get; set; } = new List<SchedulingProcedureDto?>();

		public SchedulingProductDto? SchedulingProduct { get; set; }
		public List<SchedulingProductDto?> SchedulingProducts { get; set; } = new List<SchedulingProductDto?>();

	}
}
