using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetDataNetFrameworkCodeFirst.Models
{
    public class Grade
    {
        [Column("GradeId")]
        public int GradeID { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        
        public ICollection<Student> Students { get; set; }
    }
}
