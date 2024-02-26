using Dennis.Data.MySqlClient;
using Ivony.Data.SqlClient;

namespace App.Compoment.Host
{
    public class Host
    {
        public static SqlDbExecutor DB_TVCMALL { get { return Hosting.DB_TVCMALL; } }
        public static SqlDbExecutor DB_TVC_Site { get { return Hosting.DB_TVC_Site; } }
        public static MySqlDbExecutor DB_PAYMENT { get { return Hosting.DB_PAYMENT; } }
        public static Dennis.Data.MySqlClient.MySqlDbExecutor MYSQL_DB_PAYMENT { get { return Hosting.MYSQL_DB_PAYMENT; } }
        public static Dennis.Data.MySqlClient.MySqlDbExecutor MYSQL_DB_TVC_SITE { get { return Hosting.MYSQL_DB_TVC_SITE; } }

        /// <summary>
        /// ReadOnly Access Component
        /// </summary>
        public static Dennis.Data.MySqlClient.MySqlDbExecutor MYSQL_DB_TVC_SITE_RO { get { return Hosting.MYSQL_DB_TVC_SITE_RO; } }


        private static readonly TimeZoneInfo _chinatime = TimeZoneInfo.CreateCustomTimeZone("CST", TimeSpan.FromHours(8), "Beijing Time", "China Beijing Time");

        /// <summary>
        /// 获取中国的时区
        /// </summary>
        public static TimeZoneInfo ChinaTimeZone { get { return _chinatime; } }
    }
}