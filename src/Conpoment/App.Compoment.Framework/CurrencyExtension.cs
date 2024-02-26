using App.compoment.Cache.Redis;
using App.Compoment.Host;
using Dennis.Data;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace App.Compoment.Framework
{
    public static class CurrencyExtension
    {
        private static IServiceProvider _serviceProvider;

        public static Dictionary<string, string> renameTable = new Dictionary<string, string>()
                {
                  { "MKN", "MXN" },{ "RMB", "CNY" }
                };

        // 初始化静态类的方法，传递服务提供程序
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // 在静态类中获取接口服务的方法
        public static Hosting GetHosting()
        {
            return _serviceProvider.GetRequiredService<Hosting>();
        }
        public static IRedisRepository GetRedis()
        {
     
            return _serviceProvider.GetRequiredService<IRedisRepository>();
        }

        /// <summary>
        /// 获取货币对象，用于进行货币汇率转换等辅助工作
        /// </summary>
        /// <param name="currencyCode">货币代码</param>
        /// <returns>货币对象</returns>
        public static async Task<Currency> GetCurrency(string currencyCode)
        {

            if (currencyCode == null)
                throw new ArgumentNullException("currencyCode");

            if (renameTable.ContainsKey(currencyCode))
                currencyCode = renameTable[currencyCode];

            var cache = await GetRedis().GetValueAsync(currencyCode);
            if (string.IsNullOrWhiteSpace(cache))
            {
                var result = CreateCurrencyInstance(currencyCode);
                await GetRedis().SetAsync(currencyCode, result, new TimeSpan(0, 30, 0));
                return result;
            }
            return JsonConvert.DeserializeObject<Currency>(cache);
        }

        /// <summary>
        /// 确保指定的货币代码是合法的
        /// </summary>
        /// <param name="currencyCode">货币代码</param>
        public static void EnsureCurrency(this Currency curency, ref string currencyCode)
        {
            currencyCode = GetHosting().DB_MYSQL.T("", currencyCode).ExecuteScalar<string>();
            if (currencyCode == null)
                throw new InvalidOperationException(string.Format("不存在的货币代码： {0}", currencyCode));
        }

        public static Currency CreateCurrencyInstance(string currencyCode)
        {
            var result = GetHosting().DB_MYSQL.T("S", currencyCode).ExecuteDynamicObject();

            if (result == null)
                return null;

            return new Currency()
            {
                CurrencyCode = result.CurrencyCode,
                CurrencyName = result.CurrencyName,
                Rate = result.Rate,
                SpecialRate = false,
                Symbol = result.Symbol,
                Symbol2 = result.Symbol2,
                Symbol3 = result.Symbol3,
            };
        }

    }
}
