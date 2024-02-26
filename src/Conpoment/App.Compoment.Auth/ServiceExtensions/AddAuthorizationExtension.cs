using App.Compoment.Auth.Policys;
using App.Compoment.Library.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace App.Compoment.Auth.ServiceExtensions
{
    public static class AddAuthorizationExtension
    {
        public static IServiceCollection AddServiceAuthorization(this IServiceCollection services, JwtOption option)
        {
            //JwtOption option = configuration.GetSection("JwtSetting").Get<JwtOption>() ?? new JwtOption();
            string issuer = option.Issuer;
            string audience = option.Audience;
            string secretCredentials = option.SecretKey;
            double expireMinutes = option.ExpireMinutes;
            string DirectUrl = option.DirectUrl;

            var keyByteArray = Encoding.ASCII.GetBytes(secretCredentials);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);// 签名凭据

            // 如果要数据库动态绑定，这里先留个空，后边处理器里动态赋值
            var permission = new List<PermissionItem>();
            var permissionRequirement = new PermissionRequirement(
                DirectUrl,
                permission,
                issuer,
                audience,
                signingCredentials,
                expiration: TimeSpan.FromMinutes(expireMinutes)); //过期时间

            //基于自定义策略授权
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PermissionsOption.Name,
                  policy => policy.Requirements.Add(permissionRequirement));
            });

            services.AddSingleton<IAuthorizationHandler, PermissionRequirementHandler>();
            services.AddSingleton(permissionRequirement);

            return services;
        }
    }
}
