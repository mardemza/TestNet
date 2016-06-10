using System.Data.Entity.ModelConfiguration;
using TestNet.Web.Mvc5.Models.Domain;

namespace TestNet.Web.Mvc5.Models.Domain.Configuration
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.CreatedUser)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.CreatedUserId);

            HasRequired(x => x.Job)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.JobId);
        }
    }
}