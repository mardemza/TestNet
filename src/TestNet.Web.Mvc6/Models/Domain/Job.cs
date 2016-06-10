using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestNet.Web.Mvc6.Models;
using TestNet.Web.Mvc6.Models.Domain.Enum;
using TestNet.Web.Mvc6.Models.Domain.Relation;

namespace TestNet.Web.Mvc6.Models.Domain
{
    public class Job : BaseModel
    {
        public Job()
        {
            State = StateType.OnHold;
            TagJobRelations = new HashSet<TagJob>();
            Comments = new HashSet<Comment>();
            EnabledSeeComment = false;
            EnabledDeleteComment = false;
            EnabledSeeJob = true;
            EnabledEditJob = false;
            EnabledDeleteJob = false;
            Start = DateTime.Now;
            End = Start.AddDays(1);
        }

        #region Properties

        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public StateType State { get; set; }

        public bool EnabledSeeComment { get; set; }
        public bool EnabledDeleteComment { get; set; }
        public bool EnabledSeeJob { get; set; }
        public bool EnabledEditJob { get; set; }
        public bool EnabledDeleteJob { get; set; }


        public long ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public string CreatedUserId { get; set; }
        [ForeignKey("CreatedUserId")]
        public virtual User CreatedUser { get; set; }

        public string AsignedUserId { get; set; }
        [ForeignKey("AsignedUserId")]
        public virtual User AsignedUser { get; set; }

        public virtual HashSet<TagJob> TagJobRelations { get; set; }
        public virtual HashSet<Comment> Comments { get; set; }

        #endregion

        #region Properties not mapped

        public ICollection<Tag> Tags
        {
            get
            {
                return TagJobRelations.Select(x => x.Tag).Distinct().ToList();
            }
        }

        #endregion
    }
}
