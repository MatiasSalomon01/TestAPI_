﻿namespace TestAPI_.Entities
{
    public class Student_Course
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set;}
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
