namespace SolutionsTech.MVC.Dto
{
	public class UserDto
	{
		public long IdUser { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Cel { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public DateTime DtBorn { get; set; }
		public DateTime DtCreate { get; set; } = DateTime.Now;
		public bool Active { get; set; } = true;
		public DateTime? DtDeactivation { get; set; }
		public long IdUserType { get; set; }
		public UserTypeDto? UserType { get; set; }
		public IEnumerable<UserTypeDto?> UserTypes { get; set; } = new List<UserTypeDto?>();
	}
}
