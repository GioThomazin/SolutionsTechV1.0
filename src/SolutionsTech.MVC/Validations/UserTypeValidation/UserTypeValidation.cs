using FluentValidation;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validations.UserTypeValidation
{
	public class UserTypeValidation : AbstractValidator<UserTypeDto>
	{
		public UserTypeValidation()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Campo Obrigatório")
				.NotNull()
				.Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");
		}
	}
}
