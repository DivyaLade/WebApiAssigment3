using Microsoft.EntityFrameworkCore;
using WebApiAssigment3.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiAssigment3.Context
{
    public class SchoolManagmentDBContext:DbContext
    {
        public SchoolManagmentDBContext(DbContextOptions<SchoolManagmentDBContext> options) : base(options) 
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = ADMIN; Initial Catalog = EFSchoolManagment; Integrated Security = True; Encrypt = True; Trust Server Certificate = True");
        }
    }
}
