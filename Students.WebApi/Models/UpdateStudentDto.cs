using AutoMapper;
using System;
using Students.Application.Common.Mappings;
using Students.Application.Students.Commands.UpdateStudent;

namespace Students.WebApi.Models
{
    public class UpdateStudentDto : IMapWith<UpdateStudentCommand>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateStudentDto, UpdateStudentCommand>()
                .ForMember(studentCommand => studentCommand.Id,
                    opt => opt.MapFrom(studentDto => studentDto.Id))
                .ForMember(studentCommand => studentCommand.FirstName,
                    opt => opt.MapFrom(studentDto => studentDto.FirstName))
                .ForMember(studentCommand => studentCommand.LastName,
                    opt => opt.MapFrom(studentDto => studentDto.LastName));
        }
    }
}
