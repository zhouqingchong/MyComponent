using App.compoment.Cache.Redis;
using App.Compoment.Enterprise.Site.Advertisement;
using App.Compoment.Extension.DynamoDBExtension;
using App.Compoment.Host;
using App.Compoment.Library.Page;
using App.Product.Data.IProductBase.Iproduct.Basic;
using App.Product.Data.IProductBase.IProduct.List;
using App.Site.Data.IBaseService;
using Dennis.Data;
using Dennis.Data.Queries;
using Ivony.Data;
using Newtonsoft.Json;

namespace App.Site.Data.BaseService
{
    public class AdvertisementManager : IAdvertisementManager
    {
        private IRedisRepository _redis;
        private Hosting _host;
        public IDDB_Product _ddb_Product;

        public AdvertisementManager(IRedisRepository _redis, Hosting _host, 
            IProductService productService, 
            IGeneralListItems generalList,
            IDDB_Product ddb_Product)
        {
            this._redis = _redis;
            this._host = _host;
            _ddb_Product = ddb_Product;
        }

        public Task<LongTailKeyword> GetFootLongTailKeywordList(int count = 20)
        {
            throw new NotImplementedException();
        }

        public Task<LongTailKeyword> GetLongTailKeywordList(string firstchar = "", long minId = 0, long topN = 1000)
        {
            throw new NotImplementedException();
        }

        public Task<HomePageNewarrivalAdModel> HomePageNewarrivalAdByCategoryName(string categoryname, int parentId = 0, string language = "en", string currencycode = "USD", int count = 99999)
        {
            throw new NotImplementedException();
        }

        public async Task<AdvertisementPositions[]> LoadAdvertisements(string pageType, string catalogCode = "")
        {

            return null;
        }

        public Task<ResponseResult<LongTailKeyword>> LongTailKeywordList(string firstchar = "", int pageindex = 1, int pagesize = 10)
        {
            return null;
        }

        public async Task<Advertisements[]> getAdvertisings(string positionCode, int quantity, string catalogCode)
        {
            return null;
        }
        private string generateUrl(string url, string position, string catalogCode, int sort)
        {
            if (string.IsNullOrEmpty(url))
                return "javascript:void(0);";
            return url;
        }
    }
}
