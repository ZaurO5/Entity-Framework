using Entity_Framework.Constants;
using Entity_Framework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Contexts
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.MSSQLConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().Property(x => x.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Teacher>().Property(x => x.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Student>().Property(x => x.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Assignment>().Property(x => x.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Grade>().Property(x => x.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Group>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Teacher>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Student>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Assignment>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Grade>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
