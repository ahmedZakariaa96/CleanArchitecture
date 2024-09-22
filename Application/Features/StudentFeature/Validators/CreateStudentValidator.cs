

using Application.Handlers.StudentFeature.Commends;
using Application.Handlers.StudentFeature.Services;

namespace School.Application.Handlers.StudentFeature.Validators
{
    public class CreateStudentValidator : AbstractValidator<CreateStudent>
    {
        private readonly IStudentService studentService;

 
        public CreateStudentValidator(IStudentService studentService)
        {
            this.studentService = studentService;
             applyValidationRule();
            applyCustomeValidation();

        }
        public async void applyValidationRule()
        {
 
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage("NotEmpty")
                .MaximumLength(10).WithMessage("ChractersLenght]");




        }
        public void applyCustomeValidation()
        {
            RuleFor(x => x.NameEn).MustAsync(async (Key, CancellationToken) => !await this.studentService.IsNameExist(Key))
                .WithMessage("Exist");
        }

    }
}
