using App.Compoment.Enterprise.Users;
using App.Compoment.Host;
using App.Compoment.Library.Page;
using App.Users.Data.IDataBase.IUserBase;
using Dennis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users.Data.Imp.UserBase
{
    public class UserBasic : IUserBasic
    {
        private Hosting _host;
        public UserBasic(Hosting host)
        {
            _host = host;
        }
        public async Task<bool> Available(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<bool>> ChangeBalancePassword(Guid userId, string originalPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<bool>> ChangePassword(Guid userId, string originalPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<string>> ChangeUserLevel(int Level)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<bool>> CheckBalancePassword(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<object>> ExamineBalancePassword(Guid userId, string balancePassword)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmail(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<DateTime>> GetFirstOrderOn(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<DateTime>> GetLastLogin(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<DateTime>> GetRegisterOn(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<SalesContactInfo> GetSalesContact(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<SalesContactInfo> GetSalesContact(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleMessage<Guid>> GetUserID(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<Guid>> GetUserID(string site, string email, string password, string type = null, string ip = null)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<object>> GetUserID(string site, Guid loginToken, string type = null, string ip = null)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserLanguageCode(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleMessage<int>> GetUserLevel(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleMessage<UserInfo>> GetUserRelatedInfo(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleMessage<string>> GetUserType(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<bool>> IsSubscription(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<bool>> IsSubscription(string email)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleMessage<object>> LoginWithToken(string site, Guid loginToken, string type = null, string ip = null, string countryCode = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExists(Guid userId)
        {
            return false;
        }

        public Task<SimpleMessage<bool>> UserExitbyMail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
