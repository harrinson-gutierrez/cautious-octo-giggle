using System;
namespace Application.Interfaces.Services
{
    public interface IUserContextResolverService<T>
    {
        T GetUserId();
    }
}
