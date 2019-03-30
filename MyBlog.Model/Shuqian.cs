using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Model
{
    [Table("Shuqian")]
    public class Shuqian : BaseModel
    {
        public DateTime CreateDate
        {
            get; set;
        }

        public string title
        {
            set;
            get;
        }

        public string url
        {
            set;
            get;
        }

        public string tag
        {
            set;
            get;
        }

        public int isprivate
        {
            set;
            get;
        }
    }
}
