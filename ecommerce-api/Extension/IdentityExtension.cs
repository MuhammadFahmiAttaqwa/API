using System.Security.Claims;

namespace ecommerce_api.Extension
{
    public static class IdentityExtension
    {
        public static Guid? GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null && Guid.TryParse(claim.Value, out var userId))
            {
                return userId;
            }
            return null;
        }

        public static string? GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal?.FindFirst(claimType)?.Value;
        }
    }
}
