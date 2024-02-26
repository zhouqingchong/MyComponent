using App.compoment.Cache.Redis;
using App.Compoment.Enterprise.Site.FeedBooks;
using App.Compoment.Host;
using App.Compoment.Library.Cache.RedisConfig;
using App.Compoment.Library.Page;
using App.Site.Data.IBaseService;
using Dennis.Data;
using Ivony.Data;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text.Json;

namespace App.Site.Data.BaseService
{
    public class FeedBackManager : IFeedBackManager
    {

        private IRedisRepository redis;
        private readonly Hosting hosting;
        public static Dictionary<int, int> SaveSalesDic = new Dictionary<int, int>();
        private IConfiguration configuration;

        public FeedBackManager(IRedisRepository _redis, Hosting _hosting, IConfiguration _configuration)
        {
            redis = _redis;
            hosting = _hosting;
            configuration = _configuration;
        }

        public async Task<SimpleMessage<int>> AddGuestBook(AddGuestBook book)
        {
            return null;
        }

        public async Task<SimpleMessage<string>> GetSubstringInfo(string Email)
        {
            return null;
        }

        public async Task<SimpleMessage<string>> GetSales()
        {
            return null;
        }

        public async Task<SimpleMessage<int>> GetsalesId()
        {
            return null;
        }

        public Task<SimpleMessage<bool>> FeedbackExit()
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleMessage<DataTable>> HasDiffSalesConctsData(string salesId, string email = "", string userId = "")
        {
            return null;
        }

        public async Task<SimpleMessage<bool>> UpdateSalesData(int ID, string saleId)
        {
            return null;
        }

        public async Task<SimpleMessage<string>> GetExitsalesIdByEmail(string Email)
        {
            return null;
        }

        public async void SaveSalesTimes(Dictionary<int, int> dic)
        {
            await redis.SetAsync(RedisKeys.FeedBookscacheKey, dic);
        }

        public async Task<SimpleMessage<Dictionary<int, int>>> SerializeSales()
        {
            return null;
        }

        public async Task<SimpleMessage<Dictionary<int, int>>> SalesDic()
        {
            return null;
        }
    }
}
