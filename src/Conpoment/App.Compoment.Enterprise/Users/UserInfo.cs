using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Enterprise.Users
{
    public class UserInfo
    {
        public Guid UserID { get; set; }
        public string Email { get; set; } = "";
        public string UserType { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Gender { get; set; } = "";
        public string CountryCode { get; set; } = "";
        public DateTime RegisterOn { get; set; } = DateTime.Now;
        public SalesContactInfo SalesConcact { get; set; } = null;
        public string Avatar { get; set; } = "";
        public string Phone { get; set; } = "";
    }
}
