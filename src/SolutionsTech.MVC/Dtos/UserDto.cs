
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class UserDto
	{
		public long IdUser { get; set; }
		public string Name { get; set; }
		public string Cel { get; set; }
		public string Address { get; set; }
        public DateTime DataNacimento { get; set; }
        public DateTime DtCreate { get; set; } = DateTime.Now;
		public bool Active { get; set; } = true;
		public DateTime? DtDeactivation { get; set; }
		public long IdUserType { get; set; }

		[NotMapped]
		public UserTypeDto? UserType { get; set; }

		[NotMapped]
		public List<UserTypeDto?> UserTypes { get; set; }
	}
}
