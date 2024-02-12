using AutoMapper;
using Students.Application.Common.Mappings;
using Students.Application.Students.Commands.CreateStudent;

namespace Students.WebApi.Models
{
    public class CreateStudentDto : IMapWith<CreateStudentCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public string GenderDescription { get; set; }

        public void Mpping(Profile profile)
        {
            profile.CreateMap<CreateStudentDto, CreateStudentCommand>()
                .ForMember(studentCommand => studentCommand.FirstName,
                    opt => opt.MapFrom(studentDto => studentDto.FirstName))
                .ForMember(studentCommand => studentCommand.LastName,
                    opt => opt.MapFrom(studentDto => studentDto.LastName));
        }
    }
}
