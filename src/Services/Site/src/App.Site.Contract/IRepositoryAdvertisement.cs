using App.Compoment.Enterprise.Site.Advertisement;
using App.Compoment.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Site.Contract
{
    public interface IRepositoryAdvertisement
    {
        Task<AdvertisementPositions[]> LoadAdvertisements(string pageType, string catalogCode = "");
    }
}
