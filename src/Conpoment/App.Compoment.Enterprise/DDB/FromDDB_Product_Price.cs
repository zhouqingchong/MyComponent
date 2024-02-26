using App.Compoment.Enterprise.Product;

namespace App.Compoment.Enterprise.DDB
{
    public class FromDDB_Product_Price
    {
        /// <summary>
        /// 
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DiscountRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double DiscountedPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double DiscountedPriceUSD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PriceIntervalsItem> PriceIntervals { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UpdateTime { get; set; }
    }
}
