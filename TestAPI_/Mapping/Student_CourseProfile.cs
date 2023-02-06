using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Models.Student_Course;

namespace TestAPI_.Mapping
{
    public class Student_CourseProfile : Profile
    {
        public Student_CourseProfile()
        {
            CreateMap<Student_Course, StudentCourseModel>();
            CreateMap<StudentCourseModel, Student_Course>();

            CreateMap<Student_Course, StudentCourseViewModel>()
                .ForMember(dst => dst.Name, conf => conf.MapFrom(src => src.Student.Name))
                .ForMember(dst => dst.Description, conf => conf.MapFrom(src => src.Course.Description));
        }
    }
}
