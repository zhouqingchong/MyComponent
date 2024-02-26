using App.Compoment.Enterprise.Site.FeedBooks;
using App.Compoment.Library.Page;

namespace App.Site.Contract
{
    public interface IRepositoryFeedBooks
    {
        /// <summary>
        /// 添加表单一份
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        Task<SimpleMessage<bool>> AddGuestBook(AddGuestBook books);
        /// <summary>
        /// 添加一份市场报告
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        Task<SimpleMessage<bool>> AddGuestBookForMark(AddGuestBook books);

    }
}