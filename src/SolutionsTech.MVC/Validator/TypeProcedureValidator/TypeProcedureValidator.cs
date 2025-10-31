using FluentValidation;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validator.TypeProcedureValidator
{
    public class TypeProcedureValidator : AbstractValidator<TypeProcedureDto>
    {
        private readonly ITypeProcedureService _typeProcedureService;

        public TypeProcedureValidator(ITypeProcedureService typeProcedureService)
        {
            _typeProcedureService = typeProcedureService;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome do procedimento é obrigatório.")
                .MinimumLength(2).WithMessage("O nome deve ter pelo menos 2 caracteres.")
                .MaximumLength(100).WithMessage("O nome pode ter no máximo 100 caracteres.")
                .MustAsync(async (name, _) =>
                {
                    var exists = await _typeProcedureService.ExistsByNameAsync(name);
                    return exists;
                })
                .WithMessage("Já existe um Procedimento cadastrado com esse nome.");

            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("O valor do procedimento deve ser maior que zero.");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("A duração do procedimento é obrigatória.")
                .Must(duration => duration.TotalMinutes > 0)
                .WithMessage("A duração do procedimento deve ser maior que zero minutos.");
        }
    }
}
