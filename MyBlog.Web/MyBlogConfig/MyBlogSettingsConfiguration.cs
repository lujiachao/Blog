using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.MyBlogConfig
{
    public class MyBlogSettingsConfiguration
    {
        public class DbConfigurationItem
        {
            public string ConnectionString
            {
                get; set;
            }

            public string DbType
            {
                get; set;
            }
        }

        public DbConfigurationItem DbConfiguration { get; set; }
    }
}
