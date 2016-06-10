using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestNet.Web.Mvc6.Models;

namespace TestNet.Web.Mvc6.Models.Domain
{
    public class Comment : BaseModel
    {
        #region Properties

        public string Body { get; set; }

        public string CreatedUserId { get; set; }
        [ForeignKey("CreatedUserId")]
        public virtual User CreatedUser { get; set; }

        public long JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }

        #endregion
    }
}
