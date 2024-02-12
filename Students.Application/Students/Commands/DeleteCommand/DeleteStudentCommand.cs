using System;
using MediatR;

namespace Students.Application.Students.Commands.DeleteCommand
{
    public class DeleteStudentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
