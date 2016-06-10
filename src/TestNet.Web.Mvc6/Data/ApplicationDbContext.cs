using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestNet.Web.Mvc6.Models;
using TestNet.Web.Mvc6.Models.Domain;
using TestNet.Web.Mvc6.Models.Domain.Relation;

namespace TestNet.Web.Mvc6.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // -- Config User
            //builder.Entity<User>().HasMany(x => x.Projects).WithOne(x => x.CreatedUser).HasForeignKey(x => x.CreatedUserId).IsRequired();
            //builder.Entity<User>().HasMany(x => x.JobCreateds).WithOne(x => x.CreatedUser).HasForeignKey(x => x.CreatedUserId).IsRequired();
            //builder.Entity<User>().HasMany(x => x.JobAsigneds).WithOne(x => x.AsignedUser).HasForeignKey(x => x.AsignedUserId);
            //builder.Entity<User>().HasMany(x => x.Comments).WithOne(x => x.CreatedUser).HasForeignKey(x => x.CreatedUserId).IsRequired();
            

            // -- Config Project
            //builder.Entity<Project>().HasOne(x=> x.CreatedUser).WithMany(x => x.Projects).HasForeignKey(x => x.CreatedUserId).IsRequired();            
            //builder.Entity<Project>().HasMany(x=> x.Jobs).WithOne(x => x.Project).HasForeignKey(x => x.ProjectId).IsRequired();            
            //builder.Entity<Project>().HasMany(x=> x.TagProjectRelations).WithOne(x => x.Project).HasForeignKey(x => x.ProjectId).IsRequired();
            builder.Entity<Project>().Ignore(x => x.Tags);
            builder.Entity<Project>().Ignore(x => x.UsersAccount);

            // -- Config Job
            builder.Entity<Job>().HasOne(x => x.Project).WithMany(x => x.Jobs).HasForeignKey(x => x.ProjectId).IsRequired();
            builder.Entity<Job>().HasOne(x => x.AsignedUser).WithMany(x => x.JobAsigneds).HasForeignKey(x => x.AsignedUserId);
            builder.Entity<Job>().HasOne(x => x.CreatedUser).WithMany(x => x.JobCreateds).HasForeignKey(x => x.CreatedUserId).IsRequired();
            //builder.Entity<Job>().HasMany(x => x.TagJobRelations).WithOne(x => x.Job).HasForeignKey(x => x.JobId).IsRequired();
            //builder.Entity<Job>().HasMany(x => x.Comments).WithOne(x => x.Job).HasForeignKey(x => x.JobId).IsRequired();
            builder.Entity<Job>().Ignore(x => x.Tags);
            // -- Config Cooment
            builder.Entity<Comment>().HasOne(x => x.CreatedUser).WithMany(x => x.Comments).HasForeignKey(x => x.CreatedUserId).IsRequired();
            builder.Entity<Comment>().HasOne(x => x.Job).WithMany(x => x.Comments).HasForeignKey(x => x.JobId).IsRequired();

            // -- Config Tag
            //builder.Entity<Tag>().HasMany(x => x.TagJobRelations).WithOne(x => x.Tag).HasForeignKey(x => x.TagId).IsRequired();
            //builder.Entity<Tag>().HasMany(x => x.TagProjectRelations).WithOne(x => x.Tag).HasForeignKey(x => x.TagId).IsRequired();
            builder.Entity<Tag>().Ignore(x => x.Jobs);
            builder.Entity<Tag>().Ignore(x => x.Projects);

            // -- Config TagProject            
            builder.Entity<TagProject>().HasOne(x => x.Tag).WithMany(x => x.TagProjectRelations).HasForeignKey(x => x.TagId).IsRequired();
            builder.Entity<TagProject>().HasOne(x => x.Project).WithMany(x => x.TagProjectRelations).HasForeignKey(x => x.ProjectId).IsRequired();

            // -- Config TagJob            
            builder.Entity<TagJob>().HasOne(x => x.Tag).WithMany(x => x.TagJobRelations).HasForeignKey(x => x.TagId).IsRequired();
            builder.Entity<TagJob>().HasOne(x => x.Job).WithMany(x => x.TagJobRelations).HasForeignKey(x => x.JobId).IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
