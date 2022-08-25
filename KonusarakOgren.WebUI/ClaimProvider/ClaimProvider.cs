using KonusarakOgren.Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace KonusarakOgren.WebUI.ClaimProvider
{
    public class ClaimProvider : IClaimsTransformation
    {
        public UserManager<AppUser> userManager { get; set; }

        public ClaimProvider(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal != null && principal.Identity.IsAuthenticated)
            {
                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;

                AppUser user = await userManager.FindByNameAsync(identity.Name);
            }

            return principal;
        }
    }
}