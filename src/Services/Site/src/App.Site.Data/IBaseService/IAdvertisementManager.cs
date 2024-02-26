using App.Compoment.Enterprise.Site.Advertisement;
using App.Compoment.Library.Page;

namespace App.Site.Data.IBaseService
{
    public interface IAdvertisementManager
    {
        /// <summary>
        /// 加载广告位的数据（手机端和移动端一起）
        /// </summary>
        /// <param name="pageType"></param>
        /// <param name="catalogCode"></param>
        /// <returns></returns>
        Task<AdvertisementPositions[]> LoadAdvertisements(string pageType, string catalogCode = "");

        /// <summary>
        /// 首页新口分类广告数据
        /// </summary>
        Task<HomePageNewarrivalAdModel> HomePageNewarrivalAdByCategoryName(string categoryname, int parentId = 0, string language = "en", string currencycode = "USD", int count = 99999);

        /// <summary>
        /// 长尾词数据查询接口  
        /// </summary>
        Task<LongTailKeyword> GetLongTailKeywordList(string firstchar = "", long minId = 0, long topN = 1000);
       
        /// <summary>
        /// 长尾词数据查询接口  
        /// </summary>
        Task<ResponseResult<LongTailKeyword>> LongTailKeywordList(string firstchar = "", int pageindex = 1, int pagesize = 10);
        /// <summary>
        /// 页脚长尾词查询
        /// </summary>
        Task<LongTailKeyword> GetFootLongTailKeywordList(int count = 20);

       Task<Advertisements[]> getAdvertisings(string positionCode, int quantity, string catalogCode);
    }
}
