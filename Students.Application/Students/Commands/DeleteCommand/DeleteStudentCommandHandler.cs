using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain;
using Students.Application.Common.Exceptions;
using Students.Application.Interfaces;

namespace Students.Application.Students.Commands.DeleteCommand
{
    public class DeleteStudentCommandHandler
        : IRequestHandler<DeleteStudentCommand>
    {
        private readonly IStudentsDbContext _dbContext;

        public DeleteStudentCommandHandler(IStudentsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteStudentCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Students
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id) 
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            _dbContext.Students.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}