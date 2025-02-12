using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.Business.Entity
{
    public class UserType
    {
        [Key]
        public long IdUserType { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
    }
}
