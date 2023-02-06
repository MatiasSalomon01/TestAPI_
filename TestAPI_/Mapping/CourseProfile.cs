using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Models.Course;

namespace TestAPI_.Mapping
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseModel>();
            CreateMap<CourseModel, Course>();

            CreateMap<Course, CourseViewModel>();
            //CreateMap<CourseViewModel, Course>();

        }
    }
}
