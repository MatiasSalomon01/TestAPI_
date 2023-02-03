namespace TestAPI_.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Student_Course> Student_Course { get; set; }

    }
}
