using Microsoft.Extensions.DependencyInjection;

namespace App.Configurations
{
    public static class Startup
    {
        internal static WebApplicationBuilder AddConfigurations(this WebApplicationBuilder builder)
        {
            const string configurationsDirectory = "Configurations";
            var env = builder.Environment;
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"{configurationsDirectory}/logger.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"{configurationsDirectory}/sqlconnection.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"{configurationsDirectory}/openapi.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"{configurationsDirectory}/openapi.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                 .AddJsonFile($"{configurationsDirectory}/security.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"{configurationsDirectory}/securityheaders.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"{configurationsDirectory}/RedisOption.json", optional: false, reloadOnChange: true)
                 .AddEnvironmentVariables();
            return builder;
        }

    }
}
