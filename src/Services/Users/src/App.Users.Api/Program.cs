using App.Compoment.Host;
using App.Configurations;
using App.Compoment.Swagger;
using App.Compoment.Extension;
using DMS.Common.JsonHandler.JsonConverters;
using App.Compoment.Extension.LogExtension.Serilog;
using App.Users.Api;

var builder = WebApplication.CreateBuilder(args);

//配置文件
builder.AddConfigurations();

builder.Services.AddControllers(option =>
{
    //全局处理过滤器
    // option.Filters.Add<GlobalExceptionFilter>();
}).AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
});
//注入host
builder.Services.AddTransient(provider => new Hosting(builder.Configuration));

#region 跨域请求
builder.Services.AddCors(opt =>
   opt.AddPolicy("CorsPolicy", policy =>
       policy.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials()
           .WithOrigins(new string[]{ 

                       })));
#endregion

builder.RegisterSerilog();

builder.Services.AddSwaggerGenSetup(option =>
{
    option.RootPath = AppContext.BaseDirectory;
    option.XmlFiles = new List<string> {
                     AppDomain.CurrentDomain.FriendlyName+".xml",
                     "AppUserApi.xml"
                };
}).AddRouting(options => options.LowercaseUrls = true);

//开启HttpContext服务
builder.Services.AddHttpContextSetup();

//开启身份认证服务，与api文档验证对应即可，要先开启redis服务
builder.Services.AddServiceExtension(builder.Configuration);

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

app.Run();
