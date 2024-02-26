using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Enterprise.Site.FeedBooks
{
    public class AddGuestBook
    {
        public int Type { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string CountryCode { get; set; } = "US";
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; } = "";

        public Guid UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public string Context { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public string SiteName { get; set; } = "NewTvcmall";

        /// <summary>
        /// 
        /// </summary>
        public string ImageUrl { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateOn { get; set; } = DateTime.Now;


        /// <summary>
        /// 
        /// </summary>
        public string ex1 { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public string ex2 { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public string ex3 { get; set; } = "";

        /// <summary>
        /// 站点
        /// </summary>
        public string ex4 { get; set; } = "";

        /// <summary>
        /// 备注
        /// </summary>
        public string ex5 { get; set; } = "";

        /// <summary>
        /// 业务员ID
        /// </summary>
        public string ex6 { get; set; } = "";
    }
}
