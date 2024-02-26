using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Nswagger
{
    public class TenantIdHeaderAttribute : SwaggerHeaderAttribute
    {
        public TenantIdHeaderAttribute()
        : base(
            "App.Users.Api.Test",
            "Input your tenant Id to access this API",
            string.Empty,
            true)
        {
        }
    }
}
