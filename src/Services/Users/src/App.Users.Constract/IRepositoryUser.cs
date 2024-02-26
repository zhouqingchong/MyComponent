using App.Compoment.Enterprise.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users.Constract
{
    public interface IRepositoryUser
    {
        Task<Guid> GetUserID(string Email);
        Task<int> GetUserLevel(Guid userId);
        Task<UserInfo> GetUserRelatedInfo(Guid userId);
    }
}
