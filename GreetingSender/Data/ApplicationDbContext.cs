using GreetingSender.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingSender.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Altair;Initial Catalog=GreetingService;Integrated Security=True;Trust Server Certificate=True;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
