using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Model
{
    [Table("Blog")]
    public class Blog : BaseModel
    {
        public DateTime CreateTime
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public string body
        {
            get; set;
        }

        public string body_md
        {
            get; set;
        }

        public int visitnum
        {
            get; set;
        }

        public string cabh
        {
            get; set;
        }

        public string caname
        {
            get; set;
        }

        public string remark
        {
            get; set;
        }

        public int sort
        {
            get; set;
        }
        public DateTime updatetime
        {
            get; set;
        }
    }
}
