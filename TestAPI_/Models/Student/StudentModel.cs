using TestAPI_.Entities;

namespace TestAPI_.Models.Student
{
    public class StudentModel
    {
        public string Name { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int CityId { get; set; }
    }
}
