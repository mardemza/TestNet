using System.Data.Entity.ModelConfiguration;
using TestNet.Web.Mvc5.Models.Domain;

namespace TestNet.Web.Mvc5.Models.Domain.Configuration
{
    public class JobConfiguration : EntityTypeConfiguration<Job>
    {
        public JobConfiguration()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.CreatedUser)
                .WithMany(x => x.JobCreateds)
                .HasForeignKey(x => x.CreatedUserId);

            HasOptional(x => x.AsignedUser)
                .WithMany(x => x.JobAsigneds)
                .HasForeignKey(x => x.AsignedUserId);

            HasRequired(x => x.Project)
                .WithMany(x => x.Jobs)
                .HasForeignKey(x => x.ProjectId);

            Ignore(x => x.Tags);

        }
    }
}