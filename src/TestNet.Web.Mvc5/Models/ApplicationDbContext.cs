using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TestNet.Web.Mvc5.Models.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;
using TestNet.Web.Mvc5.Models.Domain.Configuration;
using TestNet.Web.Mvc5.Models.Domain.Relation;

namespace TestNet.Web.Mvc5.Models
{

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagJob> TagJobs { get; set; }
        public virtual DbSet<TagProject> TagProjects { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // -- Configs
            modelBuilder.Configurations.Add(new ProjectConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new TagJobConfiguration());
            modelBuilder.Configurations.Add(new TagProjectConfiguration());

            base.OnModelCreating(modelBuilder);
        }        
    }
}