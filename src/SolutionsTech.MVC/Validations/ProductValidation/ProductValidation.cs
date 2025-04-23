using FluentValidation;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validations.ProductValidation
{
	public class ProductValidation : AbstractValidator<ProductDto>
	{
		public ProductValidation()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Campo Obrigatório")
				.NotNull()
				.Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");
			RuleFor(x => x.Size)
				.NotEmpty()
				.WithMessage("Campo Obrigatório")
				.NotNull();
		}
	}
}
