using SolutionsTech.Business.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
