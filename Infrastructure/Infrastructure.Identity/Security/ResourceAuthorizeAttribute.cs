using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Identity.Security
{
    public class ResourceAuthorizeAttribute : AuthorizeAttribute
    {
        public ResourceAuthorizeAttribute(string resource, string typeAction)
        {
            Policy = $"{CustomClaimTypes.Permission}:{resource}:{typeAction}";
        }
    }
}
