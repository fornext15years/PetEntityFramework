using System;
using System.Collections.Generic;
using System.Text;

namespace PetDataCoreCodeFirst.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName {get;set;}
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public int CurrentGradeId { get; set; }
        public Grade Grade { get; set; }

        public StudentAddress Address { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
