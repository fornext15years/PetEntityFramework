using PetDataCoreCodeFirst.Models;
using System;
using System.Collections.Generic;

namespace PetConsoleCoreCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //Grade grade = new Grade() { GradeName = "Grade 8", Section = "B" };
            //Student studentA = new Student() { FirstName = "Student C", CurrentGradeId=1, Height=175, Weight=53,DateOfBirth=DateTime.Now };
            //Student studentB = new Student() { FirstName = "Student D", CurrentGradeId = 1, Height = 175, Weight = 53, DateOfBirth = DateTime.Now };

            //List<object> list = new List<object>();
            //list.Add(grade);
            //list.Add(studentA);
            //list.Add(studentB);

            //using (var context = new SchoolContext())
            //{
            //    context.AddRange(list);
            //    context.SaveChanges();
            //}

            //

            TestAddRange(5);
            Console.ReadKey();
        }

        static void TestShadowProperties()
        {
            using (var context = new SchoolContext())
            {
                var entityTypes = context.Model.GetEntityTypes();

                foreach (var entityType in entityTypes)
                {
                    var props = entityType.GetProperties();
                    foreach(var prop in props)
                    {
                        if (prop.IsShadowProperty)
                        {
                            Console.WriteLine($"Entity : {entityType.Name}, ShadowProperty :{prop.Name}");
                        }
                    }
                }
            }

            Console.ReadKey();

        }

        static void TestInsertCourse()
        {
            Course course = new Course() { CourseName = "History2"};

            using (var context = new SchoolContext())
            {
                context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Added;                

                context.SaveChanges();
            }

            Console.ReadKey();
        }

        static void TestAddMultiple()
        {
            using (var context = new SchoolContext())
            {
                context.Grades.Add(new Grade() { GradeName = "Grade 1", Section = "A" });
                context.Grades.Add(new Grade() { GradeName = "Grade 2", Section = "A" });
                context.Grades.Add(new Grade() { GradeName = "Grade 3", Section = "A" });
                context.Grades.Add(new Grade() { GradeName = "Grade 4", Section = "A" });

                context.SaveChanges();
            }
        }

        static void TestAddRange(int batchSize)
        {
            List<Grade> gradeList = new List<Grade>();

            for(int i=0; i<batchSize; i++)
            {
                Grade grade = new Grade() { GradeName = $"Grade {i+1}", Section = (i+1).ToString() };
                gradeList.Add(grade);
            }
            

            using (var context = new SchoolContext())
            {
                context.Grades.AddRange(gradeList);
                
                context.SaveChanges();
            }

            Console.WriteLine("done. please enter any key to continue");
        }
    }
}
