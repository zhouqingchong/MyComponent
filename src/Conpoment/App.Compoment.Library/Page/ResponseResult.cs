using MessagePack;
using Newtonsoft.Json;
using System.Collections;

namespace App.Compoment.Library.Page
{
    [MessagePackObject(true)]
    public class ResponseResult<T>
    {
        /// <summary>
        /// 输出状态码
        /// </summary> 
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key(0)]
        public int Code { get; set; }

        /// <summary>
        /// 输出状态消息
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key(1)]

        public string Message { get; set; }

        /// <summary>
        /// 输出数据
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key(2)]
        public T Data { get; set; }

        /// <summary>
        /// 输出页码信息
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key(3)]
        public ResponsePage Pages { get; set; }


        /// <summary>
        /// 输出汇总数据
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key(4)]
        public Hashtable Totals { get; set; }

        /// <summary>
        /// 输出签名
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key(5)]

        public string Sign { get; set; }
    }

    public class ResponseResult
    {
        public static ResponseResult<T> Init<T>()
        {
            return new ResponseResult<T>()
            {
                Code = 400,
                Message = "Fail"
            };
        }
    }
}
