using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetDataNetFrameworkCodeFirst.Models
{
    public class Student
    {
        [Column("StudentId")]
        public int StudentID { get; set;}
        [Required]
        [MaxLength(50)]
        public string StudentName { get; set; }
        [Column("DOB")]
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        [ForeignKey("Grade")]
        public int? GradeRefId { get; set; }
        public Grade Grade { get; set; }

        public virtual StudentAddress Address { get; set; }
    }
}
