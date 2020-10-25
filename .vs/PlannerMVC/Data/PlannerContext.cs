using Microsoft.EntityFrameworkCore;
using PlannerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerMVC.Data
{
    public class PlannerContext : DbContext
    {
        public PlannerContext()
        {
        }

        public PlannerContext(DbContextOptions<PlannerContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activity { get; set; }
        public DbSet<Day> Day { get; set; }
        public DbSet<Link> Link { get; set; }
    }
}
