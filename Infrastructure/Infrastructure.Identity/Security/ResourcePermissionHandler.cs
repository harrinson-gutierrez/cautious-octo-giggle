using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Security
{
    public class ResourcePermissionHandler : AuthorizationHandler<ResourcePermissionRequirement>
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        private readonly IPermissionRepository PermissionRepository;

        public ResourcePermissionHandler(IHttpContextAccessor httpContextAccesso, IPermissionRepository permissionRepository)
        {
            HttpContextAccessor = httpContextAccesso;
            PermissionRepository = permissionRepository;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourcePermissionRequirement requirement)
        {
            var userId = context.User.Claims.FirstOrDefault(c => c.Type == "id");

            if (userId is null)
            {
                context.Fail();
            }
            else
            {
                var permissions = await PermissionRepository.GetPermissionsByUserId(int.Parse(userId.Value));

                var foundPermission = permissions.FirstOrDefault(x => x.name.Equals($"{requirement.Resource}:{requirement.TypeAction}"));

                if (foundPermission == null)
                    context.Fail();
                else
                    context.Succeed(requirement);
            }
        }
    }
}
