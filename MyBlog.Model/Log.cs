using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Model
{
    [Table("Log")]
    public class Log : BaseModel
    {
        public DateTime CreateDate
        {
            get; set;
        }
        public int Type
        {
            get; set;
        }

        public int userid
        {
            get; set;
        }

        public string username
        {
            get; set;
        }

        public string remark
        {
            get; set;
        }

        public string ip
        {
            get; set;
        }

        public string ipaddress
        {
            get; set;
        }
    }
}
