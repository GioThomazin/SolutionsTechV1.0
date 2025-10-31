using FluentValidation;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Interfaces.Repository;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validator.SchedulingValidator
{
    public class SchedulingValidator : AbstractValidator<SchedulingDto>
    {
        public SchedulingValidator()
        {
            RuleFor(x => x.Observation)
                .MaximumLength(500).WithMessage("A Observação pode ter no máximo 500 caracteres.");
        }
    }
}
