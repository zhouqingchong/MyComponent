using Dennis.Data.MySqlClient;
using Dennis.Data;
using Ivony.Data.SqlClient;
using Ivony.Data;
using Microsoft.Extensions.Configuration;

namespace App.Compoment.Host
{
    public class Hosting
    {
        private static object _sync = new object();
        /// <summary>
        /// 获取用于同步的对象
        /// </summary>
        public static object SyncRoot
        {
            get { return _sync; }
        }
        private static IConfiguration? _config;
        /// <summary>
        /// 初始化宿主
        /// </summary>
        /// <param name="configuration">HTTP 配置信息</param>
        public Hosting(IConfiguration config)
        {
            _config = config;
            lock (Hosting.SyncRoot)
            {
                DB_Mssql = SqlServer.Connect(_config.GetConnectionString(""));
                DB_MYSQL = MySqlDb.Connect(_config.GetConnectionString(""));
            }
        }


        public SqlDbExecutor DB_Mssql { get; set; }
        public MySqlDbExecutor DB_MYSQL { get; set; }

        /// <summary>
        /// 转换 UTC 时间到默认时区
        /// </summary>
        /// <param name="utcDate">UTC 时间</param>
        /// <returns></returns>
        public DateTime ConvertTime(DateTime utcDate)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDate, TimeZoneInfo.Local);
        }
        /// <summary>
        /// 转换 UTC 时间到默认时区
        /// </summary>
        /// <param name="utcDate">UTC 时间</param>
        /// <returns></returns>
        public DateTime? ConvertTime(DateTime? utcDate)
        {
            if (utcDate == null)
                return null;

            else
                return ConvertTime(utcDate.Value);

        }
    }
}
