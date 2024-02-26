using Microsoft.AspNetCore.Builder;

namespace App.Compoment.Swagger
{
    public static class SwaggerUIBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="isDebug"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app, bool isDebug)
        {
            if (isDebug)
            {
                app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", AppDomain.CurrentDomain.FriendlyName);
                    // 路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                    //c.RoutePrefix = "";

                });
            }
            return app;
        }
    }
}
