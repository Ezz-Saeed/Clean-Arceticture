using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Services;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private IStudentService _studentService;
        #endregion

        #region Ctors
        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("{PropertyName} field is required")
                .MaximumLength(10).WithMessage("Max length for {PropertyName} is 10 characters!");

            RuleFor(s => s.Address).NotEmpty().WithMessage("{PropertyName} field is required")
                .MaximumLength(10).WithMessage("Max length for {PropertyName} is 10 characters!");
        }

        public async void ApplyCustomValidationRules()
        {
            RuleFor(s => s.Name)
                .MustAsync(async (model, key, CancellationToken) =>
                !await _studentService.IsNameExistAsyncExcludeSelf(key, model.Id))
                .WithMessage("Student with {PropertyName} already exists");
        }
        #endregion
    }
}
