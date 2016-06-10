using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNet.Web.Mvc5.Models.Domain.Enum;
using TestNet.Web.Mvc5.Models.Domain.Relation;

namespace TestNet.Web.Mvc5.Models.Domain
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
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public StateType State { get; set; }

        public bool EnabledSeeComment { get; set; }
        public bool EnabledDeleteComment { get; set; }
        public bool EnabledSeeJob { get; set; }
        public bool EnabledEditJob { get; set; }
        public bool EnabledDeleteJob { get; set; }


        public long ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public string CreatedUserId { get; set; }        
        public virtual User CreatedUser { get; set; }

        public string AsignedUserId { get; set; }        
        public virtual User AsignedUser { get; set; }

        [JsonIgnore]
        public virtual ICollection<TagJob> TagJobRelations { get; set; }

        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }

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
