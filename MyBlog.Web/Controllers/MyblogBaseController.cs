using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Common.Enum;
using MyBlog.Web.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public class MyblogBaseController : ControllerBase
    {
        public const string DefaultDateStringFormat = "yyyy-MM-dd";

        public const string DefaultTimeStringFormat = "yyyy-MM-dd HH:mm:ss";

        //Nonaction 这并不是一个控制器，防止框架认错
        [NonAction]
        public MyblogBaseResult Successed<T>(T data, string message = "正常请求")
        {
            var resultDataSuccess = new ResultDataSuccess
            {
                GuidRequest = Guid.NewGuid().ToString(),
                Code = (int)ResultStatusCode.Success,
                Message = message,
                Data = data
            };
            return resultDataSuccess;
        }

        [NonAction]
        public MyblogBaseResult Failed<T>(T data, string message = "失败请求")
        {
            var resultDataFailed = new ResultDataFaild
            {
                GuidRequest = Guid.NewGuid().ToString(),
                Code = (int)ResultStatusCode.UnknowError,
                Message = message,
                Data = data
            };
            return resultDataFailed;
        }

        [NonAction]
        public MyblogBaseResult Exceptioned<T>(T data, int code, string message = "异常请求")
        {
            var resultDataException = new ResultDataException
            {
                GuidRequest = Guid.NewGuid().ToString(),
                Code = code,
                Message = message,
                Data = data
            };
            return resultDataException;
        }
    }
}
