using FluentValidation;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validations.TypeProcedureValidation
{
	public class TypeProcedureValidation : AbstractValidator<TypeProcedureDto>
	{
		public TypeProcedureValidation()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Campo Obrigatório")
				.NotNull()
				.Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

			RuleFor(x => x.Value)
				.GreaterThan(0)
				.WithMessage("O valor deve ser maior que zero");

			RuleFor(x => x.Duration)
				.NotNull()
				.WithMessage("Campo Obrigatório")
				.GreaterThan(TimeSpan.Zero)
				.WithMessage("A duração deve ser maior que zero");
		}
	}
}
