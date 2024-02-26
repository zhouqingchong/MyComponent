using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Nswagger.SecurityHeaders
{
    public class SecurityHeaderSettings
    {
        public bool Enable { get; set; }
        public SecurityHeaders Headers { get; set; } = default!;
    }
}
