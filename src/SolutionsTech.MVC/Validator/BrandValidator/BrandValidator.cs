using FluentValidation;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.MVC.Dto;
using System.Data;

namespace SolutionsTech.Business.Validator.BrandValidator
{
    public class BrandValidator : AbstractValidator<BrandDto>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name)
                           .NotEmpty().WithMessage("O nome da marca é obrigatório.")
                           .MinimumLength(2).WithMessage("O nome deve ter pelo menos 2 caracteres.")
                           .MaximumLength(100).WithMessage("O nome pode ter no máximo 30 caracteres.");
            RuleFor(x => x.Size)
                           .NotEmpty().WithMessage("O tamanho da marca é obrigatório.")
                           .MinimumLength(2).WithMessage("O tamanho deve ter pelo menos 2 caracteres.")
                           .MaximumLength(100).WithMessage("O tamanho pode ter no máximo 10 caracteres.");
        }
    }
}
