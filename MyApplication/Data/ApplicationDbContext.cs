using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApplication.Models;

namespace MyApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RelaxRoom> RelaxRooms { get; set; }
        public DbSet<Microwave> Microwaves { get; set; }
        public DbSet<UsingTime> UsingTimes { get; set; }
        public DbSet<Queue> Queues { get; set; }

    }
}
