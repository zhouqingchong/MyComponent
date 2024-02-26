using App.Compoment.Enterprise.Product;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Enterprise.DDB
{
    public class FromDDB_Product
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("SKU")]
        public string Sku { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EanCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Reminder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> PackageList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int HasPackage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsFake { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AuthorizationImage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Reviews { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Questions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal MinPrice { get;set; }

        /// <summary>
        /// 
        /// </summary>
        public int DiscountRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DiscountedPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal DiscountedPriceUSD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MinimumOrderQuantity { get; set; }

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
        public string CatalogCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CatalogName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HierarchyInfo HierarchyInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LeadTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StockStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SalesStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SalesRestrction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> Medias { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Promotion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PreSales { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GroupBuy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TemplateData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IsCustomize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomizeType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string CatalogsSEO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProductStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PublishDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ModifiedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProductSeries { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Coupons { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmailonlyInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ThirdPartySKU { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> Warehouse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> AllowSaleCountrys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DownShelvesDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UpshelfPlatType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastUpdateType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DDBUpdateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Concator Concator { get; set; }
    }
}
