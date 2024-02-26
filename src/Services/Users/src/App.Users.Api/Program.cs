using App.Compoment.Host;
using App.Configurations;
using App.Compoment.Swagger;
using App.Compoment.Extension;
using DMS.Common.JsonHandler.JsonConverters;
using App.Compoment.Extension.LogExtension.Serilog;
using App.Users.Api;

var builder = WebApplication.CreateBuilder(args);

//�����ļ�
builder.AddConfigurations();

builder.Services.AddControllers(option =>
{
    //ȫ�ִ��������
    // option.Filters.Add<GlobalExceptionFilter>();
}).AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
});
//ע��host
builder.Services.AddTransient(provider => new Hosting(builder.Configuration));

#region ��������
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

//����HttpContext����
builder.Services.AddHttpContextSetup();

//���������֤������api�ĵ���֤��Ӧ���ɣ�Ҫ�ȿ���redis����
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
