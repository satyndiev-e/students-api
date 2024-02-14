using System;
using FluentValidation;

namespace Students.Application.Students.Queries.GetStudentList
{
    public class GetStudentListQueryValidator : AbstractValidator<GetStudentListQuery>
    {
        public GetStudentListQueryValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
