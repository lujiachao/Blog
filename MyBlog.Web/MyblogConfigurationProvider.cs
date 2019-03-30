using JsonSettings;
using MyBlog.Web.MyBlogConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web
{
    public class MyblogConfigurationProvider
    {
        public static IServiceProvider serviceProvider;

        public static BasicSettaingsConfigurationProvider BP = new BasicSettaingsConfigurationProvider();

        public static string EnvironmentName
        {
            get
            {
                return BP.EnvironmentName;
            }
        }

        public static void Initialization()
        {
            ListenHostSettingsConfiguration = BP.BuildListenHostSettingsConfiguration();
            MyBlogSettingsConfiguration = BP.Build<MyBlogSettingsConfiguration>();
        }

        public static ListenHostSettingsConfiguration ListenHostSettingsConfiguration { get; set; }

        public static ListenHostSettingsConfiguration.ListenHostConfigurationItem ListenHostConfiguration
        {
            get
            {
                return ListenHostSettingsConfiguration.ListenHostConfiguration1;
            }
        }

        public static MyBlogSettingsConfiguration MyBlogSettingsConfiguration { get; set; }

        public static MyBlogSettingsConfiguration.DbConfigurationItem DbConfiguration
        {
            get
            {
                return MyBlogSettingsConfiguration.DbConfiguration;
            }
        }
    }
}
