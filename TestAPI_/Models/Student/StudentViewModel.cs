namespace TestAPI_.Models.Student
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public List<Entities.Course> Courses { get; set; }
    }
}
