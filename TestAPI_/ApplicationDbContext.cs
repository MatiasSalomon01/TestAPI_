using Microsoft.EntityFrameworkCore;
using TestAPI_.Entities;

namespace TestAPI_
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student_Course> Student_Course { get; set; }

        public DbSet<TablaUno> TablaUno { get; set; }
        public DbSet<TablaDos> TablaDos { get; set; }
        public DbSet<TablaUnoDos> TablaUnoDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
