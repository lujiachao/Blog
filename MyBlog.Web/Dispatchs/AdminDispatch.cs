using MyBlog.DAL;
using MyBlog.Web.Arguments;
using MyBlog.Web.Common.Enum;
using MyBlog.Web.MiddleWare;
using MyBlog.Web.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.Dispatchs
{
    public class AdminDispatch : BaseDispatch
    {
        Lazy<AdminDAL> _adminDAL = new Lazy<AdminDAL>();
        public async Task<ResultLogin> UserLogin(ArguUserLogin arguUserLogin)
        {
            if (string.IsNullOrWhiteSpace(arguUserLogin.UserName))
            {
                throw new MyblogException((int)EnumMyblogException.登录用户名为空, "Login failed,please check username!");
            }

            if (string.IsNullOrWhiteSpace(arguUserLogin.PassWord))
            {
                throw new MyblogException((int)EnumMyblogException.登录密码为空, "Login failed,please check password");
            }
            var result = await _adminDAL.Value.Login(arguUserLogin.UserName, arguUserLogin.PassWord);
            if (result == null)
            {
                throw new MyblogException((int)EnumMyblogException.登录失败, "Login failed,please check username and password");
            }
            return new ResultLogin { id = result.Id};
        }

    }
}
