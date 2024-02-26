using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Library.Auth
{
    public class TokenInfoResult
    {
        public bool success { get; set; }
        public string token { get; set; }
        public DateTime expires { get; set; }
        public string token_type { get; set; }
    }
}
