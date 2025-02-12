using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{
    public class User
    {
        [Key]
        public long IdUser { get; set; }
        public string Name { get; set; }
        public string Cel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DtCreate { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
        public DateTime? DtDeactivation { get; set; }
        public long? IdUserType { get; set; }

        [NotMapped]
        public UserType? UserType { get; set; }
        public List<UserType?>? UserTypes { get; set; }
    }
}
