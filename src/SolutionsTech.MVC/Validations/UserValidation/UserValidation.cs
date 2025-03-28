using FluentValidation;
using SolutionsTech.Business.Entity;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validations.UserValidation
{
	public class UserValidation : AbstractValidator<UserDto>
	{
		public UserValidation()
		{
			RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Campo Obrigatório")
			.NotNull()
			.Length(2,150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

			RuleFor(x => x.Cel)
			.NotEmpty().WithMessage("Campo Obrigatório")
			.NotNull().WithMessage("Campo Obrigatório")
			.Matches(@"^\d+$").WithMessage("Apenas números são permitidos")
			.Length(10, 11).WithMessage("Celular deve ter 10 (sem DDD) ou 11 dígitos (com DDD)");

			RuleFor(x => x.Email)
			.NotEmpty()
			.NotNull()
			.WithMessage("Campo Obrigatório")
			.EmailAddress().WithMessage("O email não é válido");

			RuleFor(x => x.Address)
			.NotEmpty()
			.NotNull()
			.WithMessage("Campo Obrigatório");

			RuleFor(x => x.DtBorn)
			.NotEmpty().WithMessage("Campo Obrigatório")
			.NotNull().WithMessage("Campo Obrigatório")
			.Must(dt => dt <= DateTime.Today).WithMessage("Data de nascimento não pode ser futura")
			.Must(dt => dt >= DateTime.Today.AddYears(-100)).WithMessage("Data de nascimento inválida");
		}
	}
}
