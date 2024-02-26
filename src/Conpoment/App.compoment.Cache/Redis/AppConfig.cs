﻿using App.compoment.Cache.Redis.Configurations;
using App.Compoment.Library.Cache;
using Microsoft.Extensions.Configuration;

namespace App.compoment.Cache.Redis
{
    public class AppConfig
    {
        public static RedisOption RedisOption
        {
            get
            {
                var Configuration = DMS.Common.AppConfig.Configuration;
                if (Configuration == null)
                {
                    throw new Exception($"Configuration is null,please load AddAppSettingsFile on Startup");
                }
                IConfigurationSection configurationSection = Configuration.GetSection("RedisConfig");
                if (configurationSection == null)
                {
                    throw new Exception($"no load redis.json file");
                }
                return configurationSection.Get<RedisOption>();
            }

        }
    }
}
