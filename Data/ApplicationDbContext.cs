using Microsoft.EntityFrameworkCore;
using MVC_Task.Models;

using System.Reflection.Metadata;


namespace MVC_Task.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Emp> employee { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Documents> Document { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emp>(ent =>
            {
                ent.HasOne(x => x.manager)
                .WithMany(x => x.emps)
                .HasForeignKey(x => x.Mid)
                .OnDelete(DeleteBehavior.Restrict);

                ent.HasOne(x => x.Department)
               .WithMany(x => x.emps)
               .HasForeignKey(x => x.DeptId)
               .OnDelete(DeleteBehavior.Restrict);

            });
        }

    }
}