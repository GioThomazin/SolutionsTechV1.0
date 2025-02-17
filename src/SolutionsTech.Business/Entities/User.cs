using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsTech.Business.Entity
{
    public class User
    {
        [Key]
        public long IdUser { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cel { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;   
        public string Address { get; set; } = string.Empty;
        public DateTime DataNacimento { get; set; }
		public DateTime DtCreate { get; set; } = DateTime.Now;
		public bool Active { get; set; } = true;
        public DateTime? DtDeactivation { get; set; }

		[ForeignKey("IdUserType")]
		public long IdUserType { get; set; }
    }
}
