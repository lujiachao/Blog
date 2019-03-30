using Microsoft.Extensions.DependencyInjection;
using MyBlog.Web.Dispatchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web
{
    public static class ExtensionDispatch
    {
        public static void AddDispatch(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(AdminDispatch));
        }
    }
}
