using System;
using AutoMapper;
using Students.Application.Common.Mappings;
using Students.Domain;

namespace Students.Application.Students.Queries.GetStudentDetails
{
    public class StudentDetailsVm : IMapWith<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDetailsVm>()
                .ForMember(studentVm => studentVm.FirstName,
                    opt => opt.MapFrom(student => student.FirstName))
                .ForMember(studentVm => studentVm.LastName,
                    opt => opt.MapFrom(student => student.LastName))
                .ForMember(studentVm => studentVm.DateOfBirth,
                    opt => opt.MapFrom(student => student.DateOfBirth))
                .ForMember(studentVm => studentVm.GenderId,
                    opt => opt.MapFrom(student => student.GenderId));
        }
    }
}
