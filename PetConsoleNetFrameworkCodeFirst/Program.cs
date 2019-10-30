using PetDataNetFrameworkCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConsoleNetFrameworkCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new SchoolContext())
            {
                var std = new Student { StudentName = "Bill" };
                ctx.Students.Add(std);
                ctx.SaveChanges();
            }
        }
    }
}
