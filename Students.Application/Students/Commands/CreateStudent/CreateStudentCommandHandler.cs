using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Application.Interfaces;
using Students.Domain;

namespace Students.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler
        :IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentsDbContext _dbContext;

        public CreateStudentCommandHandler(IStudentsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateStudentCommand request,
            CancellationToken cancellationToken)
        {
            var student = new Student
            {
                //Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                GenderId = request.GenderId,
                DateOfBirth = request.DateOfBirth
            };

            await _dbContext.Students.AddAsync(student, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return student.Id;
        }
    }
}
