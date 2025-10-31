using FluentValidation;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validator.FormPaymentValidator
{
    public class FormPaymentValidator : AbstractValidator<FormPaymentDto>
    {
        public FormPaymentValidator()
        {
                 RuleFor(x => x.Name)
                           .NotEmpty().WithMessage("O nome da marca é obrigatório.")
                           .MinimumLength(2).WithMessage("O nome deve ter pelo menos 2 caracteres.")
                           .MaximumLength(100).WithMessage("O nome pode ter no máximo 30 caracteres.");
        }
    }
}
