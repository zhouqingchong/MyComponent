using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Library.Auth
{
    /// <summary>
    /// 用户权限承载实体
    /// </summary>
    public class PermissionItem
    {
        public virtual long Id { get; set; }
        /// <summary>
        /// 请求Url
        /// </summary>
        public virtual string Url { get; set; }
    }
}
