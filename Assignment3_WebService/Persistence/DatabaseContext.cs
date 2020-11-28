using Assignment3_WebService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_WebService.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\chris\Dropbox\VIA\3. Semester\DNP\VS\DNPAssignment23\Assignment3_WebService\Database.db");
        }
    }
}
