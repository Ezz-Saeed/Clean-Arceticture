using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Services;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region
        private readonly IStudentService _studentService;
        #endregion

        #region ctors
        public AddStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
            ApplyCustomValidation();
        }
        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull()
                .MaximumLength(10).WithMessage("Max length for {PropertyName} is 10 characters!");

            RuleFor(s => s.Address).NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull()
                .MaximumLength(10).WithMessage("Max length for {PropertyName} is 10 characters!");
        }


        public void ApplyCustomValidation()
        {
            RuleFor(s => s.Name)
                .Must((key, CancellationToken) => !_studentService.IsNameExist(key.Name))
                .WithMessage("Student with name {PropertyValue} already exists!");
        }
        #endregion
    }
}
