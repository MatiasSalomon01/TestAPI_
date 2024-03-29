﻿namespace TestAPI_.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<Student_Course>? Student_Course { get;set; }
    }
}
