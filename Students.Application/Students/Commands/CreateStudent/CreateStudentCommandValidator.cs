using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator() 
        {
            RuleFor(createStudentCommand =>
                createStudentCommand.FirstName).NotEmpty().WithMessage("First Name is required.").MaximumLength(100);
            RuleFor(createStudentCommand =>
                createStudentCommand.LastName).NotEmpty().WithMessage("Last Name is required").MaximumLength(100);
            RuleFor(createStudentCommand =>
                createStudentCommand.DateOfBirth).NotEmpty().WithMessage("Date of Birth is required");
        }
    }
}
