using Amazon.DynamoDBv2;
using Newtonsoft.Json.Linq;
using App.Compoment.Extension.DynamoDBExtension;

namespace App.Compoment.DynamoDB.Repositories
{
    public class DDB_Product_Price : IDDB_Product_Price
    {
        private AmazonDynamoDBClient _client;
        public DDB_Product_Price(AmazonDynamoDBClient client)
        {
            _client = client;
        }

        public async Task<List<Enterprise.DDB.FromDDB_Product_Price>> BatchGetItemAsync(string[] skus, string currencyCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(string sku, string currencyCode, string languageCode)
        {
            throw new NotImplementedException();
        }

        public async Task<JObject> DescribeTableAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Enterprise.DDB.FromDDB_Product_Price> GetItemAsync(string sku, string currencyCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutItemAsync(string sku, string currencyCode, string languageCode, Enterprise.DDB.FromDDB_Product_Price product_Price)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(string sku, string currencyCode, string languageCode, Enterprise.DDB.FromDDB_Product_Price product_Price)
        {
            throw new NotImplementedException();
        }
    }
}
