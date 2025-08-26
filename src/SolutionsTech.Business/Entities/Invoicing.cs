using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entities
{
   public class Invoicing
    {
		[Key]
		public int IdInvoicing { get; set; }
		public string Scheduling { get; set; }
		public decimal TotalValue { get; set; }
		public decimal? Desconto { get; set; }
		public decimal? ValorFinal { get; set; }
		public string FormPayment { get; set; }
		public DateTime DataFaturamento { get; set; } = DateTime.Now;
		public string Observation { get; set; }
		public void CreateInvoicing(Invoicing invoicingValores)
		{
		}	
	}
}
