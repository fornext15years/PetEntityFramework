using System;
using System.Collections.Generic;
using System.Text;

namespace PetDataCoreCodeFirst.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
