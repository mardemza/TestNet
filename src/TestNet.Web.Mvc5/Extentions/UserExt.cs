using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace TestNet.Web.Mvc5.Extentions
{
    public static class UserExt
    {
        public static string GetUserId(this IPrincipal user)
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
            }
            return "";
        }
    }
}
