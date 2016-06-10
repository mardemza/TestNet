using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestNet.Web.Mvc6.Models.Domain.Relation
{
    public class TagJob: BaseModel
    {
        public long TagId { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }

        public long JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
    }
}
