using FluentValidation;
using SolutionsTech.Business.Entity;

namespace SolutionsTech.Business.Validations
{
	public class ProductValidation : AbstractValidator<Product>
	{
		public ProductValidation()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("O nome do produto é obrigatório.")
				.MinimumLength(2).WithMessage("O nome deve ter pelo menos 2 caracteres.")
				.MaximumLength(100).WithMessage("O nome pode ter no máximo 100 caracteres.");

			RuleFor(x => x.Size)
				.MaximumLength(30).WithMessage("O Tamanho pode ter no máximo 30 caracteres.")
				.When(x => !string.IsNullOrWhiteSpace(x.Size));
		}
	}
}
