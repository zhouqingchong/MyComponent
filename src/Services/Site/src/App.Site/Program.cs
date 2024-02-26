using DMS.Common.JsonHandler.JsonConverters;
using App.Compoment.Extension.LogExtension.Serilog;
using App.Site;
using App.Compoment.Swagger;
using App.Compoment.Extension.ConsulExtension;
using App.Compoment.Library.Gateway;
using System.Net;
using App.Compoment.Library.Auth;
using System.Configuration;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddConfigurations();

builder.Services.AddControllers(option =>
{
    //全局处理过滤器
    // option.Filters.Add<GlobalExceptionFilter>();
}).AddJsonOptions(option =>
{
    option.JsonSerializerOptions.PropertyNamingPolicy = null;
    option.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
    option.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
});
builder.RegisterSerilog();

builder.Services.AddService(builder.Configuration).AddRepository();



var app = builder.Build();

app.UseSwaggerUI(true);
app.UseStaticFiles()
   .UseRouting()
   .UseCors("CorsPolicy")
   .UseAuthentication()
   .UseAuthorization()
   .UseSwaggerUI()
   .UseEndpoints(endpoints =>
   {
       endpoints.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}");
   });
//就可以在这做服务注册
app.Services.GetService<IConsulRegister>()!.UseConsulRegist();
app.UseOcelot();
app.Run();
