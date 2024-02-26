using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Library.Auth
{
    /// <summary>
    /// 认证模式
    /// </summary>
    public enum AuthModel
    {
        /// <summary>
        /// cookies认证
        /// </summary>
        Cookies,
        /// <summary>
        /// token认证
        /// </summary>
        Token,
        /// <summary>
        /// jwt+redis认证
        /// </summary>
        Jwt,
        /// <summary>
        /// id4+redis认证
        /// </summary>
        Id4
    }
}
