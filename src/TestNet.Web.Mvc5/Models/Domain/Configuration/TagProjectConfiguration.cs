using System.Data.Entity.ModelConfiguration;
using TestNet.Web.Mvc5.Models.Domain;
using TestNet.Web.Mvc5.Models.Domain.Relation;

namespace TestNet.Web.Mvc5.Models.Domain.Configuration
{
    public class TagProjectConfiguration : EntityTypeConfiguration<TagProject>
    {
        public TagProjectConfiguration()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Tag)
                .WithMany(x => x.TagProjectRelations)
                .HasForeignKey(x => x.TagId);

            HasRequired(x => x.Project)
                .WithMany(x => x.TagProjectRelations)
                .HasForeignKey(x => x.ProjectId);
        }
    }
}