using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Library.Auth
{
    public class PermissionData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LinkUrl { get; set; }
        public bool IsDeleted { get; set; }

        public static implicit operator List<object>(PermissionData v)
        {
            throw new NotImplementedException();
        }
    }
}
