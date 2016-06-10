using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNet.Web.Mvc6.Models.Domain.Relation;

namespace TestNet.Web.Mvc6.Models.Domain
{
    public class Tag : BaseModel
    {
        public Tag()
        {
            TagJobRelations = new HashSet<TagJob>();
            TagProjectRelations = new HashSet<TagProject>();
        }

        #region Properties

        public string Name { get; set; }

        public virtual HashSet<TagJob> TagJobRelations { get; set; }
        public virtual HashSet<TagProject> TagProjectRelations { get; set; }
        
        #endregion
        
        #region Properties not mapped

        public ICollection<Job> Jobs
        {
            get
            {
                return TagJobRelations.Select(x => x.Job).Distinct().ToList();
            }
        }
        
        public ICollection<Project> Projects
        {
            get
            {
                return TagProjectRelations.Select(x => x.Project).Distinct().ToList();
            }
        }

        #endregion

    }
}
