using Amazon.DynamoDBv2.Model;
using App.Compoment.Enterprise.DDB;
using Newtonsoft.Json.Linq;

namespace App.Compoment.Extension.DynamoDBExtension
{
    public interface IDDB_Product_Price
    {
        /// <summary>
        /// 增删改查
        /// </summary>
        /// <typeparam name="TableName"></typeparam>
        /// <param name="sku"></param>
        /// <param name="currencyCode"></param>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        Task<FromDDB_Product_Price> GetItemAsync(string sku, string currencyCode);
        Task<bool> DeleteItemAsync(string sku, string currencyCode, string languageCode);
        Task<bool> UpdateItemAsync(string sku, string currencyCode, string languageCode, FromDDB_Product_Price product_Price);
        Task<bool> PutItemAsync(string sku, string currencyCode, string languageCode, FromDDB_Product_Price product_Price);

        /// <summary>
        /// 批量获取
        /// </summary>
        /// <typeparam name="TableName"></typeparam>
        /// <param name="skus"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        Task<List<FromDDB_Product_Price>> BatchGetItemAsync(string[] skus, string currencyCode);
        /// <summary>
        /// 获取表状态
        /// </summary>
        /// <typeparam name="TableName"></typeparam>
        /// <returns></returns>
        Task<JObject> DescribeTableAsync();
    }
}
