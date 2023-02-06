using TestAPI_.Entities;

namespace TestAPI_.Models.Student_Course
{
    public class StudentCourseViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public string Description { get; set; }
    }
}
