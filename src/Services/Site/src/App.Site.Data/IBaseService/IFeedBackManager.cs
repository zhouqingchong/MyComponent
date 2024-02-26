using App.Compoment.Enterprise.Site.FeedBooks;
using App.Compoment.Library.Page;
using System.Data;

namespace App.Site.Data.IBaseService
{
    public interface IFeedBackManager
    {
        /// <summary>
        /// 品牌官网 添加表单
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<SimpleMessage<int>> AddGuestBook(AddGuestBook book);
        /// <summary>
        /// 是否订阅
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        Task<SimpleMessage<string>> GetSubstringInfo(string Email);
        /// <summary>
        /// 获取当前业务员轮询状况
        /// </summary>
        /// <returns></returns>
        Task<SimpleMessage<string>> GetSales();
        /// <summary>
        /// 获取业务员Id
        /// </summary>
        /// <returns></returns>
        Task<SimpleMessage<int>> GetsalesId();
        /// <summary>
        /// 表单是否存在
        /// </summary>
        /// <returns></returns>
        Task<SimpleMessage<bool>> FeedbackExit();
        /// <summary>
        /// 是否存在不同业务员的表单数据
        /// </summary>
        /// <param name="salesId"></param>
        /// <param name="email"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SimpleMessage<DataTable>> HasDiffSalesConctsData(string salesId, string email = "", string userId = "");
        /// <summary>
        /// 修改表单业务员
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="saleId"></param>
        /// <returns></returns>
        Task<SimpleMessage<bool>> UpdateSalesData(int ID, string saleId);

        /// <summary>
        /// 获取游客表单中邮件已绑定的业务员
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        Task<SimpleMessage<string>> GetExitsalesIdByEmail(string Email);
        /// <summary>
        /// 保存业务员轮询次数信息
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        void SaveSalesTimes(Dictionary<int, int> dic);
        /// <summary>
        /// 解析缓存中的业务员信息
        /// </summary>
        /// <returns></returns>
        Task<SimpleMessage<Dictionary<int, int>>> SerializeSales();

        Task<SimpleMessage<Dictionary<int, int>>> SalesDic();
    }
}
