using System;
using MediatR;

namespace Students.Application.Students.Queries.GetStudentDetails
{
    public class GetStudentDetailsQuery : IRequest<StudentDetailsVm>
    {
        public int Id { get; set; }
    }
}
