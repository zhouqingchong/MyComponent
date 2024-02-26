using App.Compoment.Auth.UserContext.Jwt;
using App.Compoment.Library.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace App.Compoment.Auth.ServiceExtensions
{
    public static class UserContextService
    {
        public static void AddUserContextSetup(this IServiceCollection services,AuthModel authModel = AuthModel.Jwt)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (authModel==AuthModel.Jwt)
            {
                services.AddSingleton<IuserAuth, UserAuth>();
            }
           
        }
    }
}
