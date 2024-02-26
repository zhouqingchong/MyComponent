using App.Compoment.Enterprise.Users;
using App.Users.Constract;
using App.Users.Data.IDataBase.IUserBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users.Core
{
    public class RepositoryUser : IRepositoryUser
    {
        private IUserBasic _user;
        public RepositoryUser(IUserBasic user) 
        {
            _user=user;
        }
        public async Task<Guid> GetUserID(string Email)
        {
            var result= await _user.GetUserID(Email);
            return result.data;
        }

        public async Task<int> GetUserLevel(Guid userId)
        {
            var result = await _user.GetUserLevel(userId);
            return result.data;
        }

        public async Task<UserInfo> GetUserRelatedInfo(Guid userId)
        {
           var result=await _user.GetUserRelatedInfo(userId);
            return result.data;
        }
    }
}
