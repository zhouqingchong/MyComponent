﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Library.Auth
{
    public class PermissionsOption
    {
        /// <summary>
        /// 策略名称
        /// </summary>
        public const string Name = "Permisson";

        /// <summary>
        /// 当前项目是否启用IDS4权限方案
        /// true：表示启动IDS4
        /// false：表示使用JWT
        public static bool IsUseIds4 = false;

        /// <summary>
        /// 
        /// </summary>
        public static string ValidAudience;

        public static string valid
        {
            get
            {
                return "";
            }
        }
    }
}
