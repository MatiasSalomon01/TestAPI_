using AutoMapper;
using System.Runtime.CompilerServices;
using TestAPI_.Entities;
using TestAPI_.Models.Student;

namespace TestAPI_.Mapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentModel>();
            CreateMap<StudentModel, Student>();

            CreateMap<Student, StudentViewModel>()
                .ForMember(dst => dst.CityName, conf => conf.MapFrom(src => src.City.Name))
                .ForMember(dst => dst.CountryName, conf => conf.MapFrom(src => src.City.Country.Name))
                .ForMember(dst => dst.Courses, conf => conf.MapFrom(src => src.Student_Course.Select(x => x.Course).ToList()));
        }
    }
}
