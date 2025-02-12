using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{
    public class Scheduling
    {
        [Key]
        public long IdScheduling { get; set; }
        public string Name { get; set; }
        public DateTime DtCreate { get; set; } = DateTime.Now;
        public decimal TotalValue { get; set; }
        public string Observation { get; set; }
		
        
        // Propriedades de navegação
		public User User { get; set; }
		public FormPayment FormPayment { get; set; }
        public long IdUser { get; set; }
        public long IdFormPayment { get; set; }


	}
}
//pedir para o chat, boas praticas e refinamento da modelagem