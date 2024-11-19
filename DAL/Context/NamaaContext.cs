using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class NamaaContext: DbContext
    {
        public NamaaContext(DbContextOptions<NamaaContext> options) : base(options)
        {

        }

        public DbSet<Project> projects { get; set; }
        public DbSet<Area> areas { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<News> news { get; set; }
        public DbSet<Equipement> equipments { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<JobResponsibilities> JobResponsibilities { get; set; }
        public DbSet<JobRequirements> job_requirement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Service>()
                .HasMany(s => s.Areas)
                .WithOne(a => a.Service)
                .HasForeignKey(a => a.ServiceId);
            ///////////////////////////////////////////
            modelBuilder.Entity<Area>()
                .HasMany(a => a.Projects)
                .WithOne(p => p.Area)
                .HasForeignKey(p => p.AreaId);

            modelBuilder.Entity<Area>().HasKey(a => a.AreaId);

            //////////////////////////////////////////////////////

            modelBuilder.Entity<JobRequirements>()
           .HasOne(jr => jr.job)
           .WithMany(j => j.JobRequirements)
           .HasForeignKey(jr => jr.job_Id);
           
            base.OnModelCreating(modelBuilder);

            ////////////////////////////////////////////////

            modelBuilder.Entity<JobResponsibilities>()
           .HasOne(jr => jr.job)
           .WithMany(j => j.JobResponsibilities)
           .HasForeignKey(jr => jr.job_Id);
           
            base.OnModelCreating(modelBuilder);
















        }




    }
}
