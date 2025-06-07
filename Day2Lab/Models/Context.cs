using Microsoft.EntityFrameworkCore;

namespace Day2Lab.Models
{
    public class Context : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructores { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }


        public Context() : base()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MVC_DB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
