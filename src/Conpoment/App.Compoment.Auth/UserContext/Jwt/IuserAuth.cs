using App.Compoment.Library.Auth;

namespace App.Compoment.Auth.UserContext.Jwt
{
    public interface IuserAuth
    {
        long uId { get; }
        long cId { get; }
        string EpCode { get; }
        Task<List<PermissionItem>> GetPermissionDatas();
        Task<bool> SetTokenExpireAsync(string token, DateTime exprise);
        string GetToken();
        bool IsAuthenticated();
    }
}
