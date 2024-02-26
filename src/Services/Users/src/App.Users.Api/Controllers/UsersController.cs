using App.compoment.Cache.Redis;
using App.Compoment.Auth;
using App.Compoment.Auth.Policys;
using App.Compoment.Host;
using App.Compoment.Library.Auth;
using Dennis.Data;
using DMS.Common.Model.Result;
using Ivony.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace App.Users.Api.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        string emialRegex = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";
        string userNameRegex = @"^[\u0020A-Za-z0-9_-]{0,50}$";
        private IRedisRepository redis;
        private readonly Hosting hosting;
        /// <summary>
        /// 
        /// </summary>
        private readonly PermissionRequirement _requirement;
        public UsersController(Hosting hosting, IRedisRepository redis, PermissionRequirement requirement)
        {
            this.hosting = hosting;
            this.redis = redis;
            _requirement = requirement; 
        }
        /// <summary>
        /// JWT token 生成
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetJWTToken")]
        public ResponseResult GetJWTToken()
        {
            ResponseResult result = new ResponseResult();

            var userList = new List<dynamic> {
                new { Id="12", UserName="aaa",Pwd="123456",Role="admin"},
                new { Id="45", UserName="bbb",Pwd="456789",Role="invoice"},
            };

            var user = userList.SingleOrDefault(q => q.UserName == "aaa" && q.Pwd == "123456");
            if (user == null)
            {
                result.errno = 1;
                result.errmsg = "用户名或密码错误";
                return result;
            }
            else
            {
                var userRoles = userList.Select(q => q.Role).ToList();
                //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                //需要改进：JwtClaimTypes，减少生成规则
                var claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sid, DMS.Common.Encrypt.DESHelper.Encode("aaaa")),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString())
                };
                claims.AddRange(userRoles.Select(s => new Claim(ClaimTypes.Role, s)));

                if (!PermissionsOption.IsUseIds4)
                {
                    //jwt
                    //var data = await _roleModulePermissionServices.RoleModuleMaps();
                    var data = new List<PermissionData>() {
                              new PermissionData { Id=1,  LinkUrl="/api/Oauth2/GetProduct1", Name="invoice"},
                              new PermissionData { Id=2,  LinkUrl="/api/values", Name="admin"},
                              new PermissionData { Id=3,  LinkUrl="/api/Oauth2/GetProduct2", Name="system"},
                              new PermissionData { Id=4,  LinkUrl="/api/values1", Name="system"}
                              };
                    var list = (from item in data
                                where item.IsDeleted == false
                                orderby item.Id
                                select new PermissionItem
                                {
                                    Url = item.LinkUrl,
                                    //Name = item.Name.ToStringDefault(),
                                }).ToList();

                    _requirement.Permissions = list;
                }

                var token = JwtHelper.Create(claims.ToArray(), _requirement);
                result.data = token;

            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("api/users/getuser")]
        public async Task<string> getUser()
        {
            var aa = await hosting.DB_MYSQL.T("select Count(*) from users ").ExecuteScalarAsync<int>();
            await redis.SetAsync("test", aa+"test1111111");
            Log.Information("测试..............");
            Log.Error("这是一个error测试");
            return await redis.GetValueAsync("test");
        }
    }
}