using App.Compoment.Host;
using App.IdentityServer.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ICustomJWTService _iJWTService;
        private Hosting _hosting;
        public AuthenticationController(ICustomJWTService customJWTService)
        {
            _iJWTService = customJWTService;
        }

        /// <summary>
        /// 接受用户名和密码颁发Token
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        public string Login(string Email, string password)
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(password)) //就认为你通过
            {
                //就应该生成Token 
                string token = _iJWTService.GetToken(Email, password);
                return JsonConvert.SerializeObject(new
                {
                    result = true,
                    token
                });

            }
            else
            {
                return JsonConvert.SerializeObject(new
                {
                    result = false,
                    token = ""
                });
            }
        }
    }
}
