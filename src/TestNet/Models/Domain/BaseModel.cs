using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNet.Web.Models.Domain
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            Created = DateTime.Now;
        }
        public long Id { get; set; }
        public DateTime Created { get; set; }
    }
}
