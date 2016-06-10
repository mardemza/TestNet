using System.Data.Entity.ModelConfiguration;
using TestNet.Web.Mvc5.Models.Domain;

namespace TestNet.Web.Mvc5.Models.Domain.Configuration
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            HasKey(x => x.Id);            

            Ignore(x => x.Jobs);
            Ignore(x => x.Projects);
        }
    }
}