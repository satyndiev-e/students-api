using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Students.Domain;
using Students.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Students.Application.Common.Exceptions;

namespace Students.Application.Students.Queries.GetStudentDetails
{
    public class GetStudentDetailsQueryHandler
        :IRequestHandler<GetStudentDetailsQuery, StudentDetailsVm>
    {
        private readonly IStudentsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStudentDetailsQueryHandler(IStudentsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper); 
        public async Task<StudentDetailsVm> Handle(GetStudentDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Students
                .FirstOrDefaultAsync(student =>
                student.Id == request.Id, cancellationToken);

            if(entity == null || entity.Id != request.Id) 
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            return _mapper.Map<StudentDetailsVm>(entity);
        }
    }
}
