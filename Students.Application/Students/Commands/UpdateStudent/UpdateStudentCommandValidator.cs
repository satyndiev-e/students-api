using System;
using FluentValidation;

namespace Students.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator() 
        {
            RuleFor(updateStudentCommand => updateStudentCommand.Id).NotEmpty();
            RuleFor(updateStudentCommand => updateStudentCommand.FirstName)
                .NotEmpty().MaximumLength(100);
            RuleFor(updateStudentCommand => updateStudentCommand.LastName)
               .NotEmpty().MaximumLength(100);
            RuleFor(updateStudentCommand => updateStudentCommand.DateOfBirth)
               .NotEmpty();
            //RuleFor(updateStudentCommand => updateStudentCommand.GenderId)
            //  .NotEmpty();
        }
    }
}
