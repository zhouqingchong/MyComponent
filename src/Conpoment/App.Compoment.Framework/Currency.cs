using App.compoment.Cache.Redis;
using App.Compoment.Host;
using Dennis.Data;
using Newtonsoft.Json;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace App.Compoment.Framework
{
    public class Currency
    {
        /// <summary>
        /// 货币代码
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 货币名称
        /// </summary>
        public string CurrencyName { get; set; }

        /// <summary>
        /// 货币符号
        /// </summary>
        public string Symbol { get; set; }


        /// <summary>
        /// 第二货币符号
        /// </summary>
        public string Symbol2 { get; set; }

        /// <summary>
        /// 第三货币符号
        /// </summary>
        public string Symbol3 { get; set; }

        /// <summary>
        /// 货币汇率
        /// </summary>
        public decimal Rate { get; set; }


        /// <summary>
        /// 该货币信息是否使用了特别的汇率（并非当期汇率）
        /// </summary>
        public bool SpecialRate { get; set; }



        /// <summary>
        /// 获取一个匿名对象，其包含了货币的必要信息
        /// </summary>
        /// <param name="withRate">是否包含汇率信息</param>
        /// <returns></returns>
        public object GetCurrencyInfo(bool withRate = false)
        {

            if (withRate)
                return new
                {
                    this.CurrencyCode,
                    this.CurrencyName,
                    this.Symbol,
                    this.Symbol2,
                    this.Symbol3,
                    this.Rate,
                    this.SpecialRate,
                };

            else
                return new
                {
                    this.CurrencyCode,
                    this.CurrencyName,
                    this.Symbol,
                    this.Symbol2,
                    this.Symbol3,
                };

        }


        /// <summary>
        /// 从美元金额转换为本地货币金额
        /// </summary>
        /// <param name="amount">金额</param>
        /// <returns>本地货币金额</returns>
        public decimal ExchangeFromUSD(decimal amount)
        {
            return Round(Round(amount) * Rate);
        }

        /// <summary>
        /// 从本地货币金额转换为美元金额
        /// </summary>
        /// <param name="amount">金额</param>
        /// <returns>本地货币金额</returns>
        public decimal ExchangeToUSD(decimal amount)
        {
            return Round(Round(amount) / Rate);
        }


        public static string FormatAmountFromat(string FormatString, decimal amount)
        {
            return string.Format(FormatString, Round(amount));
        }

        /// <summary>
        /// 将金额舍入到两位小数
        /// </summary>
        /// <param name="amount">金额</param>
        /// <returns>舍入后的结果</returns>
        public static decimal Round(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }


        /// <summary>
        /// 将金额舍入到两位小数
        /// </summary>
        /// <param name="amount">金额</param>
        /// <returns>舍入后的结果</returns>
        public static decimal? Round(decimal? amount)
        {
            if (amount == null)
                return null;

            return Math.Round(amount.Value, 2, MidpointRounding.AwayFromZero);
        }


        /// <summary>
        /// 获取货币对象并使用指定的汇率
        /// </summary>
        /// <param name="currencyCode">货币代码</param>
        /// <param name="currencyRate">货币汇率</param>
        /// <returns></returns>
        public static Currency GetCurrency(string currencyCode, decimal currencyRate)
        {

            if (currencyCode == null)
                throw new ArgumentNullException("currencyCode");


            var currency = CurrencyExtension.CreateCurrencyInstance(currencyCode);
            if (currency == null)
                return null;


            if (currency.Rate != currencyRate)
            {
                currency.Rate = currencyRate;
                currency.SpecialRate = true;
            }

            return currency;
        }

        /// <summary>
        /// 获取默认货币代码
        /// </summary>
        public static string DefaultCurrencyCode { get; set; }

        /// <summary>
        /// 获取默认货币
        /// </summary>
        public static Currency DefaultCurrency { get { return CurrencyExtension.GetCurrency(DefaultCurrencyCode).Result; } }

        static Currency()
        {
            DefaultCurrencyCode = "USD";
        }


    }
}