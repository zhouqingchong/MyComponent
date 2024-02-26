using App.Compoment.Auth.UserContext.Jwt;
using DMS.Common.Helper;
using DMS.Common.JsonHandler;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace App.Compoment.Auth.Policys
{
    public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
    {
        public IAuthenticationSchemeProvider Schemes { get; set; }
        private readonly IHttpContextAccessor _accessor;
        private readonly IuserAuth _userAuth;

        public PermissionRequirementHandler(IAuthenticationSchemeProvider schemes, IHttpContextAccessor accessor, IuserAuth userAuth)
        {
            Schemes = schemes;
            _accessor = accessor;
            _userAuth = userAuth;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var httpContext = _accessor.HttpContext;
            if (httpContext != null)
            {
                var questUrl = httpContext.Request.Path.Value;//.ToLower();
                var defaultAuthenticate = await Schemes.GetDefaultAuthenticateSchemeAsync();
                if (defaultAuthenticate != null)
                {
                    var result = await httpContext.AuthenticateAsync(defaultAuthenticate.Name);
                    if (result.Succeeded)
                    {
                        if (result?.Principal != null)
                        {
                            long uId = _userAuth.uId;
                            long cId = _userAuth.cId;
                            string epcode = _userAuth.EpCode;
                            string token = _userAuth.GetToken();
                            bool isAuth = _userAuth.IsAuthenticated();

                            httpContext.User = result.Principal;

                            #region 验证接口权限
                            var list = await _userAuth.GetPermissionDatas();
                            requirement.Permissions = list;
                            string permission = $"资源权限校验:uId={uId},quesurl={questUrl}====menuList={JsonSerializerExtensions.SerializeBytes(list)}";
                            ConsoleHelper.WriteInfoLine($"userauth:permission={permission}");
                            //判断角色与Url是否对应
                            var menu = requirement.Permissions.Where(x => x.Url.ToLower().Equals(questUrl)).FirstOrDefault();
                            if (menu == null)
                            {
                                ConsoleHelper.WriteInfoLine($"接口权限不足，未匹配到URL:{uId},{questUrl}");
                                context.Fail();
                                return;
                            }
                            else
                            {
                                await _userAuth.SetTokenExpireAsync(token, DateTime.Now.Add(requirement.Expiration));
                                context.Succeed(requirement);
                            }
                            #endregion
                            return;
                        }
                    }
                }
            }
            context.Fail();
        }
    }
}
