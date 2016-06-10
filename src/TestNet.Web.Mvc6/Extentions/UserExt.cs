using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestNet.Web.Mvc6.Data;

namespace TestNet.Web.Mvc6.Extentions
{
    public static class UserExt
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    // the principal identity is a claims identity.
                    // now we need to find the NameIdentifier claim
                    var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                        return userIdClaim.Value;
                    }
                }


                //var userLo = context.Users.FirstOrDefault(x => x.Email.ToLower() == user.Identity.Name);
                //if (userLo != null) return userLo.Id;
            }
            return "";
        }
    }
}
