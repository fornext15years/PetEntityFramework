﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetDataCoreCodeFirst.Models;

namespace PetDataCoreCodeFirst.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20191029030909_ChangedShadowPropertyTypeAsNullable")]
    partial class ChangedShadowPropertyTypeAsNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetDataCoreCodeFirst.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("PetDataCoreCodeFirst.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("GradeName");

                    b.Property<string>("Section");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("PetDataCoreCodeFirst.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("CurrentGradeId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<decimal>("Height");

                    b.Property<string>("Lastname");

                    b.Property<byte[]>("Photo");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<float>("Weight");

                    b.HasKey("StudentId");

                    b.HasIndex("CurrentGradeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("PetDataCoreCodeFirst.Models.StudentAddress", b =>
                {
                    b.Property<int>("StudentAddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("AddressOfStudentId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("StudentAddressId");

                    b.HasIndex("AddressOfStudentId")
                        .IsUnique();

                    b.ToTable("StudentAddresses");
                });

            modelBuilder.Entity("PetDataCoreCodeFirst.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("CourseId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("PetDataCoreCodeFirst.Models.Student", b =>
                {
                    b.HasOne("PetDataCoreCodeFirst.Models.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("CurrentGradeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetDataCoreCodeFirst.Models.StudentAddress", b =>
                {
                    b.HasOne("PetDataCoreCodeFirst.Models.Student", "Student")
                        .WithOne("Address")
                        .HasForeignKey("PetDataCoreCodeFirst.Models.StudentAddress", "AddressOfStudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetDataCoreCodeFirst.Models.StudentCourse", b =>
                {
                    b.HasOne("PetDataCoreCodeFirst.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetDataCoreCodeFirst.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
