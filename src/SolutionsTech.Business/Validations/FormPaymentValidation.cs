using FluentValidation;
using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Validations
{
	public class FormPaymentValidation : AbstractValidator<FormPayment>
	{
		public FormPaymentValidation()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("O nome da forma de pagamento é obrigatório.")
				.MinimumLength(2).WithMessage("O nome deve ter pelo menos 2 caracteres.")
				.MaximumLength(100).WithMessage("O nome pode ter no máximo 30 caracteres.");
		}
	}
}
