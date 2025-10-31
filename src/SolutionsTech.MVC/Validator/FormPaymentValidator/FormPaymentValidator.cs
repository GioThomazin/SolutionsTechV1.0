using FluentValidation;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validator.FormPaymentValidator
{
    public class FormPaymentValidator : AbstractValidator<FormPaymentDto>
    {
        private readonly IFormPaymentService _formPaymentService;
        public FormPaymentValidator()
        {
            RuleFor(x => x.Name)
                      .NotEmpty().WithMessage("O nome da marca é obrigatório.")
                      .MinimumLength(2).WithMessage("O nome deve ter pelo menos 2 caracteres.")
                      .MaximumLength(100).WithMessage("O nome pode ter no máximo 30 caracteres.")
                      .MustAsync(async (name, _) =>
                      {
                          var exists = await _formPaymentService.ExistsByNameAsync(name);
                          return exists;
                      })
                      .WithMessage("Já existe uma Forma de Pagamento cadastrada com esse nome.");
        }
    }
}
