using MessagePack;
using Newtonsoft.Json;

namespace App.Compoment.Library.Page
{
    /// <summary>
    /// 页码信息输出
    /// </summary>
    [MessagePackObject(true)]
    public class ResponsePage
    {
        /// <summary>
        /// 页索引
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key(0)]
        public int? PageIndex { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key(1)]
        public int? PageSize { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key(2)]
        public int? PageTotal { get; set; }


        /// <summary>
        /// 总数量
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key(3)]
        public int? TotalCount { get; set; }

        public ResponsePage() { }

        public ResponsePage(int totalCount, int pagesize, int pageIndex)
        {
            TotalCount = totalCount < 0 ? 0 : totalCount;
            PageSize = pagesize == 0 ? 10 : pagesize;
            PageIndex = pageIndex == 0 ? 1 : pageIndex;
            PageTotal = (TotalCount % PageSize) == 0 ?
                (TotalCount / PageSize) :
                (TotalCount / PageSize) + 1;
        }
    }
}
