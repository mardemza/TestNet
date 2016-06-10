using System.Data.Entity.ModelConfiguration;
using TestNet.Web.Mvc5.Models.Domain;

namespace TestNet.Web.Mvc5.Models.Domain.Configuration
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.CreatedUser)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.CreatedUserId);

            Ignore(x => x.UsersAccount);
            Ignore(x => x.Tags);            
        }
    }
}