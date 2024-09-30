using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MigrationTester.Models;

namespace MigrationTester.Data
{
    public class MigDbContext : DbContext
    {
        public MigDbContext (DbContextOptions<MigDbContext> options)
            : base(options)
        {
        }

          protected override void OnConfiguring(DbContextOptionsBuilder options) {
         options.UseSqlite($"Data Source=MigTester.db");
  
        }

        public DbSet<Role> Role { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Test> Test { get; set; } = default!;
        public DbSet<Result> Result { get; set; } = default!;

        public DbSet<TestRole> TestRole { get; set;} = default!;
        
        public DbSet<Gcc> Gcc { get; set;} = default!;

        public DbSet<Module> Module { get; set;} = default!;

        public DbSet<Procedure> Procedures{ get; set; } = default!;
    
    }
}
