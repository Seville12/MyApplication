using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MyApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DRelaxRoom> DRelaxRooms { get; set; }
        public DbSet<DMicrowave> DMicrowaves { get; set; }
        public DbSet<DUsingTime> DUsingTimes { get; set; }
        public DbSet<DQueue> DQueues { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DRelaxRoom>().HasKey(m => m.RelaxRoomId);
            builder.Entity<DMicrowave>().HasKey(m => m.MicrowaveId);
            builder.Entity<DUsingTime>().HasKey(m => m.UsingTimeId);
            builder.Entity<DQueue>().HasKey(m => m.QueueId);
            base.OnModelCreating(builder);
        }
    }
}
