using HRManagement.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.DAL.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
     
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)"); 
        
    }
        public DbSet<Employee> Employees { get; set; }

    }
}
