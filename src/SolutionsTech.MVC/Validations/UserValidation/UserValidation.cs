using FluentValidation;
using SolutionsTech.Business.Entity;

namespace SolutionsTech.MVC.Validations.UserValidation
{
	public class UserValidation : AbstractValidator<User>
	{
		public UserValidation()
		{
			RuleFor(x => x.Name)
			.NotEmpty()
			.NotNull()
			.WithMessage("Campo Obrigatório");

			RuleFor(x => x.Address)
			.NotEmpty()
			.NotNull()
			.WithMessage("Campo Obrigatório");

			RuleFor(x => x.DtCreate)
			.NotEmpty()
			.NotNull()
			.WithMessage("Campo Obrigatório");

			RuleFor(x => x.DtBorn)
			.NotEmpty()
			.NotNull()
			.WithMessage("Campo Obrigatório");


			RuleFor(x => x.Cel)
			.NotEmpty()
			.NotNull()
			.WithMessage("Campo Obrigatório");
		}
	}
}
