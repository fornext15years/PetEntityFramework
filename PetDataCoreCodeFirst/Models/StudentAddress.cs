using System;
using System.Collections.Generic;
using System.Text;

namespace PetDataCoreCodeFirst.Models
{
    public class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public string Address { get; set; }

        public int AddressOfStudentId { get; set; }
        public Student Student { get; set; }
    }
}
