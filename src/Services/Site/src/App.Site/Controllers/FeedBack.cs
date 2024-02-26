using App.Compoment.Enterprise.Site.FeedBooks;
using App.Site.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Site.Controllers
{
    /// <summary>
    /// 表单
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBack : ControllerBase
    {
        private IRepositoryFeedBooks _repository;
        public FeedBack(IRepositoryFeedBooks repository) 
        { 
            this._repository = repository;
        }

        /// <summary>
        /// 普通表单
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add/books")]
        public async Task<object> AddBooks(AddGuestBook book)
        {
           var result=await _repository.AddGuestBook(book);
            return result;
        }

        /// <summary>
        /// 普通表单
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add/bookFormark")]
        public async Task<object> AddGuestBookForMark(AddGuestBook book)
        {
            var result = await _repository.AddGuestBookForMark(book);
            return result;
        }
    }
}
