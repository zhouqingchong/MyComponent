using App.Compoment.Framework;

namespace App.Compoment.Enterprise.Site.Advertisement
{
    public class HomePageNewarrivalAdModel
    {
        public int Id { get; set; } = 0;
        public string CategoryName { get; set; } = "";
        public string Url { get; set; } = "";
        public int ParentId { get; set; } = 0;
        public string[] Images { get; set; }
        public object? Products { get; set; }
    }
}
