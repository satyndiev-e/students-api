using System;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Students.Application.Students.Queries.GetStudentList;
using Students.Application.Students.Queries.GetStudentDetails;
using Students.Application.Students.Commands.CreateStudent;
using Students.Application.Students.Commands.UpdateStudent;
using Students.Application.Students.Commands.DeleteCommand;
using Students.WebApi.Models;

namespace Students.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        private readonly IMapper _mapper;

        public StudentController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<StudentListVm>> GetAll()
        {
            var query = new GetStudentListQuery
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetailsVm>> Get(int id)
        {
            var query = new GetStudentDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateStudentDto createStudentDto)
        {
            var command = _mapper.Map<CreateStudentCommand>(createStudentDto);
            command.Id = Id;
            var studentId = await Mediator.Send(command);
            return Ok(studentId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentDto updateStudentDto)
        {
            var command = _mapper.Map<UpdateStudentCommand>(updateStudentDto);
            command.Id = Id; 
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteStudentCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
