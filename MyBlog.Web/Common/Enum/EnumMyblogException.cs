using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.Common.Enum
{
    public enum EnumMyblogException
    {
        入参为空 = 1000,
        登录失败 = 1001,
        登录用户名为空 = 1002,
        登录密码为空 = 1003,    
    }
}
