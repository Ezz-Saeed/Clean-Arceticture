using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region ctors
        public AddStudentValidator()
        {
            ApplyValidationRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("{ProperyName} is required!")
                .NotNull()
                .MaximumLength(10).WithMessage("Max length for {ProperyName} is 10 characters!");

            RuleFor(s => s.Address).NotEmpty().WithMessage("{ProperyName} is required!")
                .NotNull()
                .MaximumLength(10).WithMessage("Max length for {ProperyName} is 10 characters!");
        }
        #endregion
    }
}
