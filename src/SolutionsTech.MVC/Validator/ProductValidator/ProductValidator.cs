using AutoMapper.Execution;
using FluentValidation;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validator.ProductValidator
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        private readonly IProductService _productService;

        public ProductValidator()
        {
            RuleFor(x => x.Name)
                           .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                           .MinimumLength(2).WithMessage("O nome deve ter pelo menos 2 caracteres.")
                           .MaximumLength(100).WithMessage("O nome pode ter no máximo 30 caracteres.")
                           .MustAsync(async (name, _) =>
                           {
                               var exists = await _productService.ExistsByNameAsync(name);
                               return exists;
                           })
                           .WithMessage("Já existe um Produto cadastrado com esse nome.");

            RuleFor(x => x.Size)
                            .NotEmpty().WithMessage("O tamanho do produto é obrigatório.")
                            .MinimumLength(1).WithMessage("O tamanho deve ter pelo menos 2 caracter.")
                            .MaximumLength(10).WithMessage("O tamanho pode ter no máximo 10 caracteres.");
        }
    }
}
