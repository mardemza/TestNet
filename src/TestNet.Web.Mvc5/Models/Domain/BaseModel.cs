using System;
using System.ComponentModel.DataAnnotations;

namespace TestNet.Web.Mvc5.Models.Domain
{
    public class BaseModel
    {
        public BaseModel()
        {
            Created = DateTime.Now;
        }

        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
    }
}
