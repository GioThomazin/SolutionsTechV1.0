using SolutionsTech.Business.Entity;
using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dtos
{
	public class InvoicingDto
	{
		[Key]
		public int IdInvoicing { get; set; }
		public Scheduling Scheduling { get; set; }
		public decimal TotalValue { get; set; }
		public decimal? Desconto { get; set; }
		public decimal? ValorFinal { get; set; }
		public FormPayment FormPayment { get; set; }
		public DateTime DataFaturamento { get; set; } = DateTime.Now;
		public string Observation { get; set; }
	}
}
