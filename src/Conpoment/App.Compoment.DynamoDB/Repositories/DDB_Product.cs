using Amazon.DynamoDBv2;
using App.compoment.Cache.Redis;
using App.Compoment.Enterprise.DDB;
using App.Compoment.Extension.DynamoDBExtension;
using App.Compoment.Extension.LogExtension.Serilog;
using Newtonsoft.Json.Linq;

namespace App.Compoment.DynamoDB.Repositories
{
    public class DDB_Product : IDDB_Product
    {
        private AmazonDynamoDBClient _client;
        public IRedisRepository _redis;
        public ILoggers _log;
        public DDB_Product(AmazonDynamoDBClient client, IRedisRepository redis, ILoggers loggers)
        {
            _client = client;
            _redis = redis;
            _log = loggers;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="skus"></param>
        /// <param name="currencyCode"></param>
        /// <param name="Language"></param>
        /// <returns></returns>
        public async Task<FromDDB_Product[]> BatchGetItemAsync(string[] skus, string currencyCode = "USD", string Language = "en")
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string sku, string currencyCode, string languageCode)
        {
            throw new NotImplementedException();
        }

        public Task<JObject> DescribeTableAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Enterprise.DDB.FromDDB_Product> GetItemAsync(string sku, string currencyCode, string languageCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutItemAsync(string sku, string currencyCode, string languageCode, FromDDB_Product_Price product_Price)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(string sku, string currencyCode, string languageCode, FromDDB_Product_Price product_Price)
        {
            throw new NotImplementedException();
        }
    }
}
