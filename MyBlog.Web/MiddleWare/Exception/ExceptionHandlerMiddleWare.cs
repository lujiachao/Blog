using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Web.Common.Enum;
using MyBlog.Web.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.MiddleWare
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 需要处理的状态码字典
        /// </summary>
        private IDictionary<int, string> exceptionStatusCodeDic;

        /// <summary>
        /// 重构方法
        /// </summary>
        /// <param name="_next"></param>
        public ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            this._next = next;
            exceptionStatusCodeDic = new Dictionary<int, string>
            {
                { 400, "服务器不理解请求语法"},
                { 401, "未授权的请求" },
                { 404, "找不到该页面" },
                { 403, "访问被拒绝" },
                { 500, "服务器发生意外的错误" }
            };
        }

        public async Task Invoke(HttpContext context)
        {
            Exception exception = null;
            try
            {
                await _next(context);

            }
            catch (Exception ex)
            {
                context.Response.Clear();
                //context.Response.StatusCode = 500;   //发生未捕获的异常，手动设置状态码
                exception = ex;
                await HandleExceptionAsync(context, exception);
            }
            //finally
            //{
            //    if (exceptionStatusCodeDic.ContainsKey(context.Response.StatusCode) &&
            //            !context.Items.ContainsKey("ExceptionHandled"))  //预处理标记
            //    {
            //        var errorMsg = string.Empty;
            //        if (context.Response.StatusCode == 500 && exception != null)
            //        {
            //            context.Response.ContentType = "application/json";
            //            errorMsg = $"{exceptionStatusCodeDic[context.Response.StatusCode]}:{(exception.InnerException != null ? exception.InnerException.Message : exception.Message)}";
            //        }
            //        else
            //        {
            //            errorMsg = exceptionStatusCodeDic[context.Response.StatusCode];
            //        }
            //        exception = new Exception(errorMsg);
            //    }
            //    await HandleExceptionAsync(context, exception);
            //}
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;
            await WriteExceptionAsync(context, exception).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception exception)
        {
            //返回友好的提示
            var response = context.Response;
            response.ContentType = "application/json";
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (exception is MyblogException)
            {
                await response.WriteAsync(JsonConvert.SerializeObject(new ResultDataException()
                {
                    Code = ((MyblogException)exception).Code,
                    Message = exception.Message,
                })).ConfigureAwait(false);
            }
            else if (exception is Exception)
            {
                await response.WriteAsync(JsonConvert.SerializeObject(new ResultDataException()
                {
                    Code = context.Response.StatusCode,
                    Message = exception.Message,
                })).ConfigureAwait(false);
            }
        }
    }
}
