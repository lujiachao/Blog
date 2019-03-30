using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Model
{
    [Table("Diary")]
    public class Diary : BaseModel
    {
        public DateTime dateTime
        {
            get; set;
        }

        public String Title
        {
            get; set;
        }

        public string body
        {
            get; set;
        }
    }
}
