using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Identity.Security
{
    public class ResourcePermissionRequirement : IAuthorizationRequirement
    {
        public string Resource { get; set; } 
        public string TypeAction { get; set; }

        public ResourcePermissionRequirement(string resource, string typeAction)
        {
            Resource = resource;
            TypeAction = typeAction;
        }
    }
}
