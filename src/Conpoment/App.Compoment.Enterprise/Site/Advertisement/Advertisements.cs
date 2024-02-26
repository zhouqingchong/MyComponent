using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Enterprise.Site.Advertisement
{
    public class Advertisements
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = ""; 
        public string Name { get; set; } = "";
        public string Url { get; set; } = "";
        public string Image { get; set; } = "";
        public bool NewWindow { get; set; }= false;
        public string BgColorL { get; set; } = "";      
        public string BgColorR { get; set; } = "";
        public string Description { get; set; } = "";
        public string EndOn { get; set; } = "";  
        public string StartOn { get; set; } = "";
        public string SKU { get; set; } = "";
        public string Type { get; set; } = "";
        public string ChildSkus { get; set; } = "";
        public string ChildImages { get; set; } = "";
        public AdvertisementsLangugeImages? LangImage { get; set; }
        public string BgImage { get; set; } = ""; 
        public int BgImageType { get; set; }
        public AdvertisementsLanguge? ExtensionsProp { get; set; }
        public string VideoCode { get; set; } = "";
        public string Icon { get; set; } = "";  
    }

    public class AdvertisementsLanguge
    {
        public Array all { get; set; }
        public Array en { get; set; }
        public Array es { get; set; }
        public Array de { get; set; }
        public Array fr { get; set; }
        public Array ru { get; set; }
        public Array it { get; set; }
        public Array pt { get; set; }

    }
    public class AdvertisementsLangugeImages
    {
        public Array en { get; set; }
        public Array es { get; set; }
        public Array de { get; set; }
        public Array fr { get; set; }
        public Array ru { get; set; }
        public Array it { get; set; }
        public Array pt { get; set; }

    }
}
