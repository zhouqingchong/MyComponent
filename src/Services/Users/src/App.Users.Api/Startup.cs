using App.compoment.Cache.Redis.Configurations;
using App.Compoment.Auth.ServiceExtensions;
using App.Compoment.Library.Auth;
using App.Compoment.Library.Cache;

namespace App.Users.Api
{
    public static class Startup
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services,IConfiguration config)
        {

            RedisOption redisOption = config.GetSection("RedisOption").Get<RedisOption>()??new RedisOption();
            if (redisOption!=null)
            {
                //开启redis服务
                services.AddRedisSetup(config);
            }
            JwtOption jwtOption = config.GetSection("JwtSetting").Get<JwtOption>()??new JwtOption();
            if (jwtOption!=null)
            {
                services.AddServiceAuthorization(jwtOption);
                //jwt授权
                services.AddAuthenticationJWT(jwtOption);
            }
            return services;
        }
    }
}
