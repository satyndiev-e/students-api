using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Students.Application.Interfaces;

namespace Students.Application.Students.Queries.GetStudentList
{
    public class GetStudentListQueryHandler
        : IRequestHandler<GetStudentListQuery, StudentListVm>
    {
        private readonly IStudentsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStudentListQueryHandler(IStudentsDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<StudentListVm> Handle(GetStudentListQuery request,
            CancellationToken cancellationToken)
        {
            var studentsQuery = await _dbContext.Students
                .Where(student => student.Id == request.Id)
                .ProjectTo<StudentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new StudentListVm { Students = studentsQuery };
        }
    }
}
