using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestNet.Models;
using TestNet.Web.Models.Domain;
using TestNet.Web.Models.Domain.Relation;

namespace TestNet.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
                       

            // -- Config Project
            builder.Entity<Project>().HasKey(x => x.Id);            
            builder.Entity<Project>().Ignore(x => x.Tags);
            builder.Entity<Project>().Ignore(x => x.UsersAccount);

            // -- Config Job
            builder.Entity<Job>().HasKey(x => x.Id);
            builder.Entity<Job>().Ignore(x => x.Tags);

            // -- Config Cooment
            builder.Entity<Comment>().HasKey(x => x.Id);            

            // -- Config Tag
            builder.Entity<Tag>().HasKey(x => x.Id);
            builder.Entity<Tag>().Ignore(x => x.Jobs);
            builder.Entity<Tag>().Ignore(x => x.Projects);

            // -- Config TagProject
            builder.Entity<TagProject>().HasKey(x => x.Id);

            // -- Config TagJob
            builder.Entity<TagJob>().HasKey(x => x.Id);           
        }
    }
}
