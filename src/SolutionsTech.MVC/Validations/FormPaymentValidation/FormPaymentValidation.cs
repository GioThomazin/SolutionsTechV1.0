using FluentValidation;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validations.FormPaymentValidation
{
	public class FormPaymentValidation : AbstractValidator<FormPaymentDto>
	{
		public FormPaymentValidation()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Campo Obrigatório")
				.NotNull()
				.Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");
		}
	}
}
