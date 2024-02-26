using App.Compoment.Enterprise.Site.Advertisement;
using App.Compoment.Framework;
using App.Site.Contract;
using App.Site.Data.IBaseService;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace App.Site.Core
{
    public class RepositoryAdvertisement : IRepositoryAdvertisement
    {
        public IAdvertisementManager _AdvertisementManager;
        public RepositoryAdvertisement(IAdvertisementManager AdvertisementManager) 
        {
            _AdvertisementManager = AdvertisementManager;
        }

        public async Task<AdvertisementPositions[]> LoadAdvertisements(string pageType, string catalogCode = "")
        {
            return await _AdvertisementManager.LoadAdvertisements(pageType, catalogCode);
        }
    }
}
