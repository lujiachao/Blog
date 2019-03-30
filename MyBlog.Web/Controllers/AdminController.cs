using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Web.Arguments;
using MyBlog.Web.Common.Enum;
using MyBlog.Web.Dispatchs;
using MyBlog.Web.MiddleWare;
using MyBlog.Web.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.Controllers
{
    [EnableCors("AllowCors")]
    [Route("api/myblog/[controller]/[action]")]
    [ApiController]
    public class AdminController : MyblogBaseController
    {
        private AdminDispatch _adminDispatch = MyblogConfigurationProvider.serviceProvider.GetRequiredService<AdminDispatch>();

        [HttpPost]
        public async Task<MyblogBaseResult> AdminLogin([FromBody]ArguUserLogin arguUserLogin)
        {
            if (arguUserLogin == null)
            {
                throw new MyblogException((int)EnumMyblogException.入参为空, "Argument is null,please check Argu");
            }
            return Successed(await _adminDispatch.UserLogin(arguUserLogin));
        }
    }
}
