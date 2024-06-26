﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using CMS_Backend.Helpers;
using System.Data;

namespace CMS_Backend.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<UserRoles> user_roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StudentInfo> StudentInfos { get; set; }
        public virtual DbSet<CollegeFaciliteis> CollegeFaciliteis { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<StudentFeedback> Feedbacks { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<FacultyInfo> FacultyInfos { get; set; }
        public virtual DbSet<Facilities> Facilities { get; set; }
        public virtual DbSet<FacultyType> FacultyTypes { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<CourseSubjects> CourseSubjects { get; set; }
        public virtual DbSet<FileRepo> FileRepos { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
        public virtual DbSet<CourseFaculties> CourseFaculties { get; set; }





        // Method to seed data if the table is empty
        public void SeedIfEmpty()
        {
            if (!Colleges.Any())
            {
                var colleges = new College[]
                {
                    new College { name = "Example College 1", description = "Description of Example College 1" },
                    new College { name = "Example College 2", description = "Description of Example College 2" },
                };

                Colleges.AddRange(colleges);
                SaveChanges();
            }
            if (!user_roles.Any())
            {
                var firstCollege = Colleges.FirstOrDefault();
                if (firstCollege != null)
                {
                    var roles = new UserRoles[]
                    {
                        new UserRoles { name = "Admin"},
                        new UserRoles { name = "Student" },
                        new UserRoles { name = "Faculty" },
                    };

                    user_roles.AddRange(roles);
                    SaveChanges();
                }
            }
            if (!Users.Any())
            {
                var firstCollege = Colleges.FirstOrDefault();
                var admin = user_roles.Where(x => x.name == "Admin").FirstOrDefault();
                if (admin != null && firstCollege != null)
                {
                    var adminEmail = $"admin{firstCollege.id}@example.com";
                    var password = "admin123";
                    var hashedPassword = HashedHelper.HashPassword(password);
                    var user = new User[]
                    {
                        new User{name = "Admin",email=adminEmail,password=hashedPassword,role_id=admin.id}
                    };
                    Users.AddRange(user);
                    SaveChanges();
                }
            }

            if (!FacultyTypes.Any())
            {
                var facultyType = new FacultyType[]
                {
                    new FacultyType { name = "professor",is_active = true},
                    new FacultyType { name = "associate professor",is_active = true },
                    new FacultyType { name = "assistant professor",is_active = true },
                };
                FacultyTypes.AddRange(facultyType);
                SaveChanges();
            }
            if (!CourseCategories.Any())
            {
                var CourseCategory = new CourseCategory[]
                {
                    new CourseCategory { name = "Sceince & Technology",is_active = true},
                    new CourseCategory { name = "Commerce",is_active = true },
                    new CourseCategory { name = "Arts",is_active = true },
                };
                CourseCategories.AddRange(CourseCategory);
                SaveChanges();
            }
        }
    }
}
