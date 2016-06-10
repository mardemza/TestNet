using System.Data.Entity.ModelConfiguration;
using TestNet.Web.Mvc5.Models.Domain;
using TestNet.Web.Mvc5.Models.Domain.Relation;

namespace TestNet.Web.Mvc5.Models.Domain.Configuration
{
    public class TagJobConfiguration : EntityTypeConfiguration<TagJob>
    {
        public TagJobConfiguration()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Tag)
                .WithMany(x => x.TagJobRelations)
                .HasForeignKey(x => x.TagId);

            HasRequired(x => x.Job)
                .WithMany(x => x.TagJobRelations)
                .HasForeignKey(x => x.JobId);
        }
    }
}