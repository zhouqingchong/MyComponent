
using App.Compoment.Enterprise.Users;
using App.Compoment.Library.Page;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users.Data.IDataBase.IUserBase
{
    public interface IUserBasic
    {
        #region 用户信息相关

        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        Task<bool> UserExists(string Email);
        Task<bool> UserExists(Guid userId);
        //是否激活状态
        Task<bool> Available(Guid userId);

        //获取用户邮件
        Task<string> GetEmail(Guid userId);

        //获取业务员信息
        Task<SalesContactInfo> GetSalesContact(Guid userId);

        //获取业务员信息
        Task<SalesContactInfo> GetSalesContact(int Id);

        // 获取用户语种
        Task<string> GetUserLanguageCode(Guid userId);

        /// <summary>
        /// 通过邮件获取用户Id
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        Task<SimpleMessage<Guid>> GetUserID(string Email);

        /// <summary>
        /// 获取用户相关信息，国家、业务员......
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<SimpleMessage<UserInfo>> GetUserRelatedInfo(Guid UserId);

        /// <summary>
        /// 获取用户等级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SimpleMessage<int>> GetUserLevel(Guid userId);

        /// <summary>
        /// 更改等级
        /// </summary>
        /// <param name="Level"></param>
        /// <returns></returns>
        Task<SimpleMessage<string>> ChangeUserLevel(int Level);

        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SimpleMessage<string>> GetUserType(Guid userId);

        /// <summary>
        /// 通过邮箱判断用户是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<SimpleMessage<bool>> UserExitbyMail(string email);

        /// <summary>
        /// 获取用户最后登陆时间
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>最后一次登陆的时间（UTC）</returns>
        Task<SimpleMessage<DateTime>> GetLastLogin(Guid userId);

        /// <summary>
        /// 获取注册时间
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>最后一次登陆的时间（UTC）</returns>
        Task<SimpleMessage<DateTime>> GetRegisterOn(Guid userId);

        /// <summary>
        /// 是否订阅邮件
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SimpleMessage<bool>> IsSubscription(Guid userId);
        Task<SimpleMessage<bool>> IsSubscription(string email);

        /// <summary>
        /// 最近下单时间
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SimpleMessage<DateTime>> GetFirstOrderOn(Guid userId);
        #endregion


        /// <summary>
        /// 用户登陆接口
        /// </summary>
        /// <param name="site"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="type"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        Task<SimpleMessage<Guid>> GetUserID(string site, string email, string password, string type = null, string ip = null);

        /// <summary>
        /// 审核支付密码是否正确
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="balancePassword"></param>
        /// <returns></returns>
        Task<SimpleMessage<object>> ExamineBalancePassword(Guid userId, string balancePassword);

        /// <summary>
        /// 获取 UserID，通过第三方登录 Token 进行登录
        /// </summary>
        /// <param name="site"></param>
        /// <param name="loginToken"></param>
        /// <param name="type"></param>
        /// <param name="ip"></param>
        Task<SimpleMessage<object>> GetUserID(string site, Guid loginToken, string type = null, string ip = null);

        /// <summary>
        /// 通过token直接登陆
        /// </summary>
        /// <param name="site"></param>
        /// <param name="loginToken"></param>
        /// <param name="type"></param>
        /// <param name="ip"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        Task<SimpleMessage<object>> LoginWithToken(string site, Guid loginToken, string type = null, string ip = null, string countryCode = null);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">当前用户ID</param>
        /// <param name="originalPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>是否修改成功等信息</returns>
        Task<SimpleMessage<bool>> ChangePassword(Guid userId, string originalPassword, string newPassword);

        /// <summary>
        /// 修改支付密码
        /// </summary>
        /// <param name="userId">当前用户ID</param>
        /// <param name="originalPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>是否修改成功等信息</returns>
        Task<SimpleMessage<bool>> ChangeBalancePassword(Guid userId, string originalPassword, string newPassword);

        /// <summary>
        ///  检查是否设置了支付密码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SimpleMessage<bool>> CheckBalancePassword(Guid userId);
    }
}
