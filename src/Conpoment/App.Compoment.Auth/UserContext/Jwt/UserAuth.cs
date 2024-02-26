using App.compoment.Cache.Redis;
using App.Compoment.Library.Auth;
using DMS.Common.Extensions;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace App.Compoment.Auth.UserContext.Jwt
{
    public class UserAuth : IuserAuth
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IRedisRepository _redisRepository;
        public UserAuth(IHttpContextAccessor accessor, IRedisRepository redisRepository)
        {
            Console.WriteLine($"App.Compoment.Auth.Oauth:{redisRepository}");
            _accessor = accessor;
            _redisRepository = redisRepository;
        }

        public UserClaimModel UserClaimModel
        {
            get
            {
                string UniqueId = GetClaimValueByType(JwtClaimTypes.UniqueId).FirstOrDefault();
                if (!UniqueId.IsNullOrEmpty())
                {
                    string[] arr = UniqueId.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                    UserClaimModel claimModel = new UserClaimModel()
                    {
                        uId = arr[0].ToLong(),
                        cId = arr[1].ToLong(),
                        EpCode = arr[2],
                    };
                    return claimModel;
                }
                return new UserClaimModel();
            }
        }
        public long uId => UserClaimModel.uId;
        public long cId => UserClaimModel.cId;
        public string EpCode
        {
            get
            {
                return UserClaimModel.EpCode;
            }
        }

        public async Task<List<PermissionItem>> GetPermissionDatas()
        {
            var token = GetToken();
            bool flag = await _redisRepository.HashExistsAsync(token, "Permission");
            if (flag)
            {
                List<PermissionItem> list = await _redisRepository.HashGeAsync<List<PermissionItem>>(token, "Permission");
                if (list!=null&&list.Count>0)
                {
                    return list;
                }
            }
            return new List<PermissionItem>();
        }

        public string GetToken()
        {
            return _accessor.HttpContext?.Request?.Headers["Authorization"].ToStringDefault().Replace("Bearer ", "");
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public async Task<bool> SetTokenExpireAsync(string token, DateTime exprise)
        {
            await _redisRepository.HashSetAsync(token, "exptime", exprise);
            return await _redisRepository.KeyExpireAsync(token, exprise);
        }

        #region private

        private string GetName()
        {
            if (IsAuthenticated() && !_accessor.HttpContext.User.Identity.Name.IsNullOrEmpty())
            {
                //var v = _accessor.HttpContext.User.Claims.Where(q => q.Type == System.Security.Claims.ClaimTypes.PrimarySid).FirstOrDefault().Value;
                return _accessor.HttpContext.User.Identity.Name;
            }
            else
            {
                if (!string.IsNullOrEmpty(GetToken()))
                {
                    var getNameType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
                    return GetUserInfoFromToken(getNameType).FirstOrDefault().ToStringDefault();
                }
            }

            return "";
        }

        public List<string> GetUserInfoFromToken(string ClaimType)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = "";

            token = GetToken();
            // token校验
            if (!token.IsNullOrEmpty() && jwtHandler.CanReadToken(token))
            {
                JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(token);

                return (from item in jwtToken.Claims
                        where item.Type == ClaimType
                        select item.Value).ToList();
            }

            return new List<string>() { };
        }
        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
        public List<string> GetClaimValueByType(string ClaimType)
        {
            return (from item in GetClaimsIdentity()
                    where item.Type == ClaimType
                    select item.Value).ToList();

        }
        #endregion
    }
}
