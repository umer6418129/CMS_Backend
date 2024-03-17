using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<Course> Courses{ get; set; }
        public virtual DbSet<StudentInfo> StudentInfos{ get; set; }






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
                        new UserRoles { name = "Admin", CollegeId = firstCollege.id },
                        new UserRoles { name = "Student", CollegeId = firstCollege.id },
                    };

                    user_roles.AddRange(roles);
                    SaveChanges();
                }
            }
            if (!Users.Any())
            {
                var firstCollege = Colleges.FirstOrDefault();
                var admin = user_roles.Where(x => x.name == "Admin" && x.CollegeId == firstCollege.id).FirstOrDefault();
                if (admin != null && firstCollege != null)
                {
                    var adminEmail = $"admin{firstCollege.id}@example.com";
                    var password = "admin123";
                    var hashedPassword = HashedHelper.HashPassword(password);
                    var user = new User[]
                    {
                        new User{name = "Admin",email=adminEmail,password=hashedPassword,role_id=admin.id,collegeId = firstCollege.id}
                    };
                    Users.AddRange(user);
                    SaveChanges();
                }
            }
        }
    }
}
