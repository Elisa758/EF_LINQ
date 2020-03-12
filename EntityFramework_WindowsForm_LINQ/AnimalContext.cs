using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EntityFramework_WindowsForm_LINQ
{
    class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Species> Species { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=Species;Integrated Security=True");
        }
    }
}
