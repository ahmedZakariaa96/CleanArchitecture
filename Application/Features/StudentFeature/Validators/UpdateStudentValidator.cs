﻿

using Application.Handlers.StudentFeature.Commends;
using Application.Handlers.StudentFeature.Services;

namespace School.Application.Handlers.StudentFeature.Validators
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudent>
    {
        private readonly IStudentService studentService;

        public UpdateStudentValidator(IStudentService studentService)
        {
            applyValidationRule();
            applyCustomeValidation();
            this.studentService = studentService;
        }
        public async void applyValidationRule()
        {

            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage("{PropertyName} is NotEmpty")
                .NotNull().WithMessage("{PropertyName} is NotNull")
                .MaximumLength(10).WithMessage("{PropertyName} should have 10 chracters");

        }
        public void applyCustomeValidation()
        {
            RuleFor(x => x.NameEn).MustAsync(async (Model, Key, CancellationToken) => !await this.studentService.IsNameExist(Key, Model.Id))
                .WithMessage("Name is exist ");
        }

    }
}
