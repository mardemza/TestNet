using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TestNet.Web.Mvc5.Models.Domain
{
    public class User : IdentityUser
    {
        public User()
        {
            JobCreateds = new HashSet<Job>();
            JobAsigneds = new HashSet<Job>();
            Comments = new HashSet<Comment>();
        }

        #region Properties

        
        public virtual HashSet<Job> JobCreateds { get; set; }        
        public virtual HashSet<Job> JobAsigneds { get; set; }        
        public virtual HashSet<Comment> Comments { get; set; }
        public virtual HashSet<Project> Projects { get; set; }

        #endregion

        #region Methods

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }

        #endregion
    }
}
