using System;
using MediatR;

namespace Students.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public int GenderId { get; set; }
    }
}
