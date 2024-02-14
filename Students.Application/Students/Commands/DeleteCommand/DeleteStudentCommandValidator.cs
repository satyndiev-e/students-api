using System;
using FluentValidation;

namespace Students.Application.Students.Commands.DeleteCommand
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(deleteStudentCommand => deleteStudentCommand.Id).NotEmpty();
        }
    }
}
