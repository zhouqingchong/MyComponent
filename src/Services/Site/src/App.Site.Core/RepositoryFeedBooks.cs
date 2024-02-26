using App.compoment.Cache.Redis;
using App.Compoment.Enterprise.Site.FeedBooks;
using App.Compoment.Library.Cache.RedisConfig;
using App.Compoment.Library.Page;
using App.Site.Contract;
using App.Site.Data.IBaseService;
using App.Users.Constract;
using StackExchange.Redis;
using System.Data;

namespace App.Site.Core
{
    public class RepositoryFeedBooks : IRepositoryFeedBooks
    {
        private IFeedBackManager feedBack;
        private IRepositoryUser user;
        private IRedisRepository redis;
        public RepositoryFeedBooks(IFeedBackManager _feedBook, IRepositoryUser _user, IRedisRepository _redis)
        {
            feedBack = _feedBook;
            user = _user;
            redis = _redis;
        }

        public async Task<SimpleMessage<bool>> AddGuestBook(AddGuestBook books)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleMessage<bool>> AddGuestBookForMark(AddGuestBook books)
        {
            throw new NotImplementedException();
        }
    }
}