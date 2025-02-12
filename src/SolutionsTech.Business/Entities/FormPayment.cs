using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{
    public class FormPayment
    {
        [Key]
        public long IdFormPayment { get; set; }
        public string Name { get; set; }
        public DateTime DtCreate { get; set; } = DateTime.Now;
        public bool Active { get; set; }
    }
}
