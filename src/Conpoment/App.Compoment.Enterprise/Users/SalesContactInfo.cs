using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Enterprise.Users
{
    public class SalesContactInfo
    {

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [JsonProperty("NickName")]
        public string Name { get; private set; } = "";
        /// <summary>
        /// 电子邮箱地址
        /// </summary>
        [JsonProperty("salesEmail")]
        public string Email { get; private set; } = "services@tvc-mall.com";
        /// <summary>
        /// Skype账号
        /// </summary>
        public string Skype { get; private set; } = "";
        /// <summary>
        /// 速卖通账号
        /// </summary>
        public string TradeManager { get; private set; } = "";
        /// <summary>
        /// 微信
        /// </summary>
        public string WeChat { get; private set; } = "";
        /// <summary>
        /// 微信
        /// </summary>
        public string WhatsApp { get; private set; } = "";
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; private set; } = "";
        /// <summary>
        /// 照片
        /// </summary>
        public string Photo { get; private set; } = "";
    }
}
