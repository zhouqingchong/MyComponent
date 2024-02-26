using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Enterprise.Site.Advertisement
{
    public class AdvertisementPositions
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int Quantity { get; set; }

        public int Width { get;set; }

        public int Height { get;set; }
        public Advertisements[] Advertisings { get; set; }
    }
}
