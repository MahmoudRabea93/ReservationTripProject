using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkTask.Model
{
    public class DataBaseContext:DbContext
    {
        public DbSet<Trip> Trips { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Reservation> Reservations { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-ESA4RRK;database=TaskDatabase;Trusted_Connection=true;");
        }
    }
}
