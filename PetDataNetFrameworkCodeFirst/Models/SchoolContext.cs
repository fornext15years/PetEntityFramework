using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDataNetFrameworkCodeFirst.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().Map(m =>
            //{
            //    m.Properties(p => new { p.StudentID, p.StudentName });
            //    m.ToTable("Students");
            //}).Map(m =>
            //{
            //    m.Properties(p => new {p.StudentID, p.Height, p.Weight, p.Photo, p.DateOfBirth });
            //    m.ToTable("StudentDetails");
            //});

            //modelBuilder.Entity<Grade>().ToTable("Grades");
            modelBuilder.Entity<Student>().HasOptional(s => s.Address).WithRequired(a => a.Student);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

    }
}
