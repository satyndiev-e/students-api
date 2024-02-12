using System.Collections.Generic;

namespace Students.Application.Students.Queries.GetStudentList
{
    public class StudentListVm
    {
        public IList<StudentLookupDto> Students { get; set; }
    }
}
