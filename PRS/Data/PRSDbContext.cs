using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PRS.Models;

namespace PRS.Data {
    public class PRSDbContext : DbContext {
        public PRSDbContext(DbContextOptions<PRSDbContext> options)
            : base(options) {
        }

        public DbSet<PRS.Models.User> User { get; set; }
        public DbSet<PRS.Models.Product> Product { get; set; }
        public DbSet<PRS.Models.Request> Request { get; set; }
        public DbSet<PRS.Models.Vendor> Vendor { get; set; }
        public DbSet<PRS.Models.Requestline> Requestline { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<User>(e => {
                e.HasIndex("Username").IsUnique();
            });

            modelBuilder.Entity<Product>(e => {
                e.HasIndex("PartNbr").IsUnique();
            });

            modelBuilder.Entity<Vendor>(e => {
                e.HasIndex("Code").IsUnique();
            });


        }
    }
}
