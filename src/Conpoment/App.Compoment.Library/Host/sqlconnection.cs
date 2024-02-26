using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Library.Host
{
    public class sqlconnection
    {
        /// <summary>
        /// 
        /// </summary>
        public ConnectionStrings connectionStrings { get; set; }
        public bool UseMysql { get; set; }
    }
    public class ConnectionStrings
    {
        /// <summary>
        /// 
        /// </summary>
        public string DB_Mssql { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DB_MYSQL { get; set; }

    }
}
