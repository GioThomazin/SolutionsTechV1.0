using FluentValidation;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Validator.UserValidator
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        private readonly IUserService _userService;

        public UserValidator()
        {
            RuleFor(x => x.Name)
                           .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                           .MinimumLength(2).WithMessage("O nome deve ter pelo menos 2 caracteres.")
                           .MaximumLength(100).WithMessage("O nome pode ter no máximo 100 caracteres.");

            RuleFor(x => x.Cel)
                            .NotEmpty().WithMessage("O celular do usuário é obrigatório.")
                            .MinimumLength(10).WithMessage("O celular deve ter pelo menos 10 caracteres.")
                            .MaximumLength(15).WithMessage("O celular pode ter no máximo 15 caracteres.");

            RuleFor(x => x.Email)
                            .NotEmpty().WithMessage("O email do usuário é obrigatório.")
                            .EmailAddress().WithMessage("O email informado não é válido.")
                            .MaximumLength(100).WithMessage("O email pode ter no máximo 100 caracteres.");

            RuleFor(x => x.DtBorn)
                            .NotEmpty().WithMessage("A data de nascimento do usuário é obrigatória.")
                            .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser uma data passada.");
        }
    }
}
