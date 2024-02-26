using App.Compoment.Library.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Compoment.Host
{
    public static class Startup
    {
        public static IServiceCollection AddHosting(this IServiceCollection services)
        {
            services.AddTransient<Hosting>();
            return services;
        }
    }
}
