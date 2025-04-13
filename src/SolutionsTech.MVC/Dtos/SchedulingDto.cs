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
        public UserDto? User { get; set; }

        public IEnumerable<UserDto?> Users { get; set; } = new List<UserDto?>();
        public FormPaymentDto? FormPayment { get; set; }
        public IEnumerable<FormPaymentDto?> FormPayments { get; set; } = new List<FormPaymentDto?>();
        public TypeProcedureDto? TypeProcedure { get; set; }
        public IEnumerable<TypeProcedureDto?> TypeProcedures { get; set; } = new List<TypeProcedureDto?>();
    }
}
