using System;
using FluentValidation;

namespace Students.Application.Students.Queries.GetStudentDetails
{
    public class GetStudentDetailsQueryValidator : AbstractValidator<GetStudentDetailsQuery>
    {
        public GetStudentDetailsQueryValidator() 
        {
            RuleFor(student => student.Id).NotEqual(null);
        }
    }
}
