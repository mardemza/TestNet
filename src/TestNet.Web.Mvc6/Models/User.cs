using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TestNet.Web.Mvc6.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestNet.Web.Mvc6.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        public User()
        {
            JobCreateds = new HashSet<Job>();
            JobAsigneds = new HashSet<Job>();
            Comments = new HashSet<Comment>();
        }

        #region Properties

        [InverseProperty("CreatedUser")]
        public HashSet<Job> JobCreateds { get; set; }

        [InverseProperty("AsignedUser")]
        public HashSet<Job> JobAsigneds { get; set; }

        [InverseProperty("CreatedUser")]
        public HashSet<Comment> Comments { get; set; }

        #endregion
    }
}
