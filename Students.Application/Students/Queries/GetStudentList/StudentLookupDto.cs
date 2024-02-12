using System;
using AutoMapper;
using Students.Domain;
using Students.Application.Common.Mappings;

namespace Students.Application.Students.Queries.GetStudentList
{
    public class StudentLookupDto : IMapWith<Student>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public int GenderId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentLookupDto>()
                .ForMember(studentDto => studentDto.Id,
                    opt => opt.MapFrom(student => student.Id))
                .ForMember(studentDto => studentDto.FirstName,
                    opt => opt.MapFrom(student => student.FirstName))
                .ForMember(studentDto => studentDto.LastName,
                    opt => opt.MapFrom(student => student.LastName));
                //.ForMember(studentDto => studentDto.DateOfBirth,
                //   opt => opt.MapFrom(student => student.DateOfBirth))
                //.ForMember(studentDto => studentDto.GenderId,
                //   opt => opt.MapFrom(student => student.GenderId));
        }
    }
}
