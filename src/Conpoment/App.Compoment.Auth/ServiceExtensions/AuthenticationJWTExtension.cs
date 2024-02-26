using App.Compoment.Auth.Policys;
using App.Compoment.Library.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace App.Compoment.Auth.ServiceExtensions
{
    public static class AuthenticationJWTExtension
    {
        public static void AddAuthenticationJWT(this IServiceCollection services, JwtOption option)
        {
            //JwtOption option = configuration.GetSection("JwtSetting").Get<JwtOption>();
            string issuer = option.Issuer;
            string audience = option.Audience;
            string secretCredentials = option.SecretKey;
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,//是否验证发行人
                ValidIssuer = issuer,//发行人

                ValidateAudience = false,//是否验证被发布者
                ValidAudience = audience,//受众人
                //这里采用动态验证的方式，在重新登陆时，刷新token，旧token就强制失效了

                ValidateIssuerSigningKey = true,//是否验证密钥
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretCredentials)),

                ValidateLifetime = false, //验证生命周期
                ClockSkew = TimeSpan.FromSeconds(30),//注意这是缓冲过期时间，总的有效时间等于这个时间加上jwt的过期时间，如果不配置，默认是5分钟
                RequireExpirationTime = false, //过期时间
            };
            //开启Bearer认证
            services.AddAuthentication(x =>
            {
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = nameof(ApiResponseHandler);
                x.DefaultForbidScheme = nameof(ApiResponseHandler);
            })
                .AddJwtBearer(o =>
                {
                    //不使用https
                    o.TokenValidationParameters = tokenValidationParameters;
                    o.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.Response.Headers.Add("Token-Error", context.ErrorDescription);
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            // 如果过期，则把<是否过期>添加到，返回头信息中
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                })
            .AddScheme<AuthenticationSchemeOptions, ApiResponseHandler>(nameof(ApiResponseHandler), o => { });
        }
    }
}
