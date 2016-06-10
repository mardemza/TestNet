﻿using System;
using System.Collections.Generic;
using System.Linq;
using TestNet.Web.Mvc5.Models.Domain.Relation;

namespace TestNet.Web.Mvc5.Models.Domain
{
    public class Project : BaseModel
    {
        public Project()
        {
            Jobs = new HashSet<Job>();
            TagProjectRelations = new HashSet<TagProject>();
            Start = DateTime.Now;
            End = Start.AddDays(1);
        }


        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string CreatedUserId { get; set; }
        public virtual User CreatedUser { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public virtual ICollection<TagProject> TagProjectRelations { get; set; }

        #endregion

        #region Properties not mapped

        public int UsersAccount
        {
            get
            {
                return Jobs.Count(x => x.AsignedUser != null);
            }
        }
        public ICollection<Tag> Tags
        {
            get
            {
                return TagProjectRelations.Select(x => x.Tag).Distinct().ToList();
            }
        }

        #endregion
    }
}
