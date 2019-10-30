using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetDataNetFramework;
using PetDataNetFramework.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json.Converters;
using System.Data.Entity.Infrastructure;

namespace PetConsoleNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSingleTransaction();
            Console.ReadKey();
        }

        static void TestConcurrency()
        {
            Student student = null;

            using (var context = new PetDemoEntities(PetDataConnectionStringBuilder.GetConnectionString()))
            {
                student = context.Students.First();
            }

            //Edit student name
            Console.Write("Enter New Student Name:");
            student.StudentName = Console.ReadLine(); //Assigns student name from console

            using (var context = new PetDemoEntities(PetDataConnectionStringBuilder.GetConnectionString()))
            {
                try
                {
                    context.Entry(student).State = EntityState.Modified;
                    context.SaveChanges();

                    Console.WriteLine("Student saved successfully.");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Concurrency Exception Occurred.");
                }
            }
        }

        static void TestStoredProcedures()
        {
            using(var db = new PetDemoEntities(PetDataConnectionStringBuilder.GetConnectionString()))
            {
                var courses = db.GetCoursesByStudentId(1).ToList();

                foreach(var course in courses)
                {
                    Console.WriteLine($"course : {course.CourseName} ");
                }
            }
        }

        static void TestEnum()
        {
            Teacher newTeacher = new Teacher();
            newTeacher.TeacherName = "Jinpyo Kim";
            newTeacher.TeacherType = TeacherType.Contract;

            using (var db = new PetDemoEntities(PetDataConnectionStringBuilder.GetConnectionString()))
            {
                
                db.Entry(newTeacher).State = newTeacher.TeacherId == 0 ? EntityState.Added : EntityState.Modified;
                //db.Teachers.Add(newTeacher);
                db.SaveChanges();                
            }
        }

        static void TestTransaction()
        {
            using (var context = new PetDemoEntities(PetDataConnectionStringBuilder.GetConnectionString()))
            {
                context.Database.Log = Console.Write;

                var standard = context.Standards.Add(new Standard() { StandardName = "1st Grade" });
                context.Students.Add(new Student()
                {
                    StudentName = "Rama",
                    StandardId = standard.StandardId
                });

                context.SaveChanges();

                context.Courses.Add(new Course() { CourseName = "Computer Science" });
                context.SaveChanges();
            }
        }

        static void TestSingleTransaction()
        {
            using (var context = new PetDemoEntities(PetDataConnectionStringBuilder.GetConnectionString()))
            {
                context.Database.Log = Console.Write;

                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var standard = context.Standards.Add(new Standard() { StandardName = "1st Grade" });

                        context.Students.Add(new Student()
                        {
                            StudentName = "Rama2",
                            StandardId = standard.StandardId
                        });
                        context.SaveChanges();

                        context.Courses.Add(new Course() { CourseName = "Computer Science" });
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
            }
        }
    }
}
