using System;
using MediatR;

namespace Students.Application.Students.Queries.GetStudentList
{
    public class GetStudentListQuery : IRequest<StudentListVm>
    {
        public int Id { get; set; }
    }
}
