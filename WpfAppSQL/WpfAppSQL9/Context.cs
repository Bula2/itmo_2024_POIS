using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data.Entity;
using WpfAppSQL9.Models;

namespace WpfAppSQL9
{

    public class SchoolContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Department> Department { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Person> Person { get; set; } 
        public Microsoft.EntityFrameworkCore.DbSet<OnsiteCourse> OnsiteCourse { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<OnlineCourse> OnlineCourse { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<StudentGrade> StudentGrade { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<CourseInstructor> CourseInstructor { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Course> Course { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<OfficeAssignment> OfficeAssignment { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Customer> Customer { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DBConnect.School"].ConnectionString);
        }

    }
}
