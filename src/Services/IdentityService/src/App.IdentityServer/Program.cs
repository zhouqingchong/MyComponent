using App.Compoment.Library.Auth;
using App.IdentityServer.Utility;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICustomJWTService, CustomHSJWTService>();
builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JWTTokenOptions"));

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
