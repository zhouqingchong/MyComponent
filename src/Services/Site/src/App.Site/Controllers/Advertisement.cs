using App.Compoment.Enterprise.Site.Advertisement;
using App.Compoment.Framework;
using App.Site.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Advertisement : ControllerBase
    {
        public IRepositoryAdvertisement _repositoryAdvertisement;
        public Advertisement(IRepositoryAdvertisement repositoryAdvertisement)
        {
          _repositoryAdvertisement = repositoryAdvertisement;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageType"></param>
        /// <param name="catalogCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/LoadAdvertisements")]
        public async Task<AdvertisementPositions[]> LoadAdvertisements(string pageType, string catalogCode = "")
        {
            return await _repositoryAdvertisement.LoadAdvertisements(pageType, catalogCode);
        }

        [HttpGet]
        [Route("Health/Index")]
        public async Task<string> Health()
        {
            return "OK";
        }
    }
}
