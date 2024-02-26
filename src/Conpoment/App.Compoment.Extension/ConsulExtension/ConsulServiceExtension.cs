using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Extension.ConsulExtension
{
    public static class ConsulServiceExtension
    {
        public static void AddConsult(this IServiceCollection service)
        {
            service.AddTransient<IConsulRegister, ConsulRegister>();
        }
    }
}
