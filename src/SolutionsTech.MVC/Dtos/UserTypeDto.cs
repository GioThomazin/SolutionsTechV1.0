using System.ComponentModel.DataAnnotations;

namespace SolutionsTech.MVC.Dto
{
	public class UserTypeDto
	{
		public long IdUserType { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; } = true;
	}
}
