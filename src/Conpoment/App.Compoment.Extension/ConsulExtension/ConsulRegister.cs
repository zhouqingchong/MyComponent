using App.Compoment.Library.Gateway;
using Consul;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Extension.ConsulExtension
{
    public class ConsulRegister : IConsulRegister
    {
        public IConfiguration _config;
        public ConsulRegister(IConfiguration config)
        {
            _config = config;
        }

        public void UseConsulRegist()
        {
            ConsulClientOptions _client = _config.GetSection("ConsulClientOptions").Get<ConsulClientOptions>() ?? new ConsulClientOptions();
            ConsulRegisterOptions _service = _config.GetSection("ConsulRegisterOptions").Get<ConsulRegisterOptions>() ?? new ConsulRegisterOptions();

            ConsulClient clien = new ConsulClient(c =>
            {
                c.Address = new Uri($"http://{_client.IP}:{_client.Port}/");
                c.Datacenter = _client.Datacenter;
            });
            {
                clien.Agent.ServiceRegister(new AgentServiceRegistration()
                {
                    ID = $"{_service.GroupName}-{_service.IP}-{_service.Port}",//唯一Id
                    Name = _service.GroupName,//组名称-Group
                    Address = _service.IP,
                    Port = _service.Port,
                    Tags = new string[] { _service.Tag ?? "Tags is null" },
                    Check = new AgentServiceCheck()
                    {
                        Interval = TimeSpan.FromSeconds(_service.Interval),
                        HTTP = _service.HealthCheckUrl,
                        Timeout = TimeSpan.FromSeconds(_service.Timeout),
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(_service.DeregisterCriticalServiceAfter),
                    }
                });
                DMS.Common.Helper.ConsoleHelper.WriteInfoLine($"{JsonConvert.SerializeObject(_service)} 完成注册");
            }

        }
    }
}
