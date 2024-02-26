using App.Compoment.Host;
using App.Compoment.Swagger;
using App.Compoment.Extension;
using App.Compoment.Library.Auth;
using App.compoment.Cache.Redis.Configurations;
using App.Compoment.Auth.ServiceExtensions;
using App.Site.Contract;
using App.Site.Core;
using App.Users.Constract;
using App.Users.Core;
using App.Site.Data.IBaseService;
using App.Site.Data.BaseService;
using App.Compoment.DynamoDB;
using App.Product.Data.IProductBase.Iproduct.Basic;
using App.Product.Data.Imp.Product.Basic;
using App.Product.Cache;
using App.Compoment.Framework;
using App.Product.Data.IProductBase.IProduct.List;
using App.Product.Data.Imp.Product.List;
using App.Product.Data.IProductBase.IProducts.Pricing;
using App.Product.Data.Imp.Products.Pricing;
using App.Users.Data.IDataBase.IUserBase;
using App.Users.Data.Imp.UserBase;
using App.Compoment.Extension.ConsulExtension;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;

namespace App.Site
{
    public static class AddServiceStartup
    {
        public static WebApplicationBuilder AddConfigurations(this WebApplicationBuilder builder)
        {
            const string configurationsDirectory = "Configurations";
            var env = builder.Environment;
            builder.Configuration
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("SalesControcts.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{configurationsDirectory}/logger.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{configurationsDirectory}/sqlconnection.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{configurationsDirectory}/openapi.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{configurationsDirectory}/RedisOption.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"{configurationsDirectory}/Gateway.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"{configurationsDirectory}/ocelot.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            return builder;
        }

        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(provider => new Hosting(configuration));

            services.AddDynamoDB(configuration);

            #region 跨域请求
            services.AddCors(opt =>
                             opt.AddPolicy("CorsPolicy",
                             policy =>
                             policy.AllowAnyHeader()
                                   .AllowAnyMethod()
                                   .AllowCredentials()
                                   .WithOrigins(new string[]{

                                   })));

            #endregion

            services.AddSwaggerGenSetup(option =>
            {
                option.RootPath = AppContext.BaseDirectory;
                option.XmlFiles = new List<string> {
                     AppDomain.CurrentDomain.FriendlyName+".xml",
                     "App.Site.xml"
                };
            }).AddRouting(options => options.LowercaseUrls = true);

            //开启HttpContext服务
            services.AddHttpContextSetup();

            //开启redis服务
            services.AddRedisSetup(configuration);

            JwtOption jwtOption = configuration.GetSection("JwtSetting").Get<JwtOption>() ?? new JwtOption();
            if (jwtOption != null)
            {
                //开启身份认证服务，与api文档验证对应即可，要先开启redis服务
                services.AddUserContextSetup();

                services.AddServiceAuthorization(jwtOption);
                //jwt授权
                services.AddAuthenticationJWT(jwtOption);
            }
            //添加网关
            services.AddConsult();
            services.AddOcelot().AddConsul().AddPolly(); //在他内部就会自动读取；读取的是默认的配置文件
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddSingleton<IRepositoryUser, RepositoryUser>();
            services.AddSingleton<IFeedBackManager, FeedBackManager>();
            services.AddSingleton<IRepositoryFeedBooks, RepositoryFeedBooks>();
            services.AddSingleton<IUserBasic, UserBasic>();
            services.AddSingleton<IProductGroupService, ProductGroupService>();
            services.AddSingleton<IProductPricingService, ProductPricingService>();
            services.AddSingleton<IProductSalesRestriction, ProductSalesRestriction>();
            services.AddSingleton<IProductStockStatus, ProductStockStatus>();
            services.AddSingleton<IProductCustomizeService, ProductCustomizeService>();
            services.AddSingleton<IRedisCache, RedisCache>();
            services.AddSingleton<IGeneralListItems, GeneralListItems>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IAdvertisementManager, AdvertisementManager>();
            services.AddSingleton<IRepositoryAdvertisement, RepositoryAdvertisement>();
            CurrencyExtension.Initialize(services.BuildServiceProvider());
            return services;
        }
    }
}
