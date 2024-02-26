﻿using App.Compoment.Library.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace App.compoment.Cache.Redis.Configurations
{
    public static class RedisServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisSetup(this IServiceCollection services, IConfiguration configuration)
        {
            RedisOption option = configuration.GetSection("RedisOption").Get<RedisOption>() ?? new RedisOption();

            if (services == null) throw new ArgumentNullException(nameof(services));
            //RedisOption option = AppConfig.RedisOption;
            if (option.Enabled)
            {
                services.AddTransient<IRedisRepository, RedisRepository>();

                //获取连接字符串

                var options = ConfigurationOptions.Parse(option.RedisConnectionString, true);
                options.AbortOnConnectFail = false;//服务器上停止redis service，即便后来redis服务端修好能够接通时，也不会自动连接。
                                                   //options.Password = option.RedisConnectionPwd;
                                                   //options.ResolveDns = true;
                var connect = ConnectionMultiplexer.Connect(options);
                //注册如下事件
                connect.ConnectionFailed += MuxerConnectionFailed;
                connect.ConnectionRestored += MuxerConnectionRestored;
                connect.ErrorMessage += MuxerErrorMessage;
                connect.ConfigurationChanged += MuxerConfigurationChanged;
                connect.HashSlotMoved += MuxerHashSlotMoved;
                connect.InternalError += MuxerInternalError;
                DMS.Common.Helper.ConsoleHelper.WriteInfoLine($"AddRedisSetup:IsConnected={connect.IsConnected},RedisOption={option.RedisConnectionString}");
                services.AddSingleton<ConnectionMultiplexer>(connect);
            }
            return services;
        }

        #region 事件
        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConfigurationChanged(object sender, EndPointEventArgs e)
        {
            System.Console.WriteLine("Configuration changed: " + e.EndPoint);
        }

        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerErrorMessage(object sender, RedisErrorEventArgs e)
        {
            System.Console.WriteLine("ErrorMessage: " + e.Message);
        }

        /// <summary>
        /// 重新建立连接之前的错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            System.Console.WriteLine("ConnectionRestored: " + e.EndPoint);
        }

        /// <summary>
        /// 连接失败 ， 如果重新连接成功你将不会收到这个通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            System.Console.WriteLine("重新连接：Endpoint failed: " + e.EndPoint + ", " + e.FailureType + (e.Exception == null ? "" : (", " + e.Exception.Message)));
        }

        /// <summary>
        /// 更改集群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerHashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
            System.Console.WriteLine("HashSlotMoved:NewEndPoint" + e.NewEndPoint + ", OldEndPoint" + e.OldEndPoint);
        }

        /// <summary>
        /// redis类库错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerInternalError(object sender, InternalErrorEventArgs e)
        {
            System.Console.WriteLine("InternalError:Message" + e.Exception.Message);
        }

        #endregion 事件
    }
}
