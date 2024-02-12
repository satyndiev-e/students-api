using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain;
using Microsoft.EntityFrameworkCore;
using Students.Application.Common.Exceptions;
using Students.Application.Interfaces;

namespace Students.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IStudentsDbContext _dbContext;

        public UpdateStudentCommandHandler(IStudentsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateStudentCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Students.FirstOrDefaultAsync(student =>
                    student.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            entity.FirstName =request.FirstName;
            entity.LastName =request.LastName;
            entity.DateOfBirth =request.DateOfBirth;
            entity.GenderId = request.GenderId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
