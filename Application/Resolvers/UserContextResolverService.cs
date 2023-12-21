using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Application.Resolvers
{
    public class UserContextResolverService : IUserContextResolverService<int>
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        public UserContextResolverService(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            return int.Parse(HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("id"))?.Value);
        }
    }
}
