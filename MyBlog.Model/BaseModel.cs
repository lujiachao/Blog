using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Model
{
    public class BaseModel
    {
        /// <summary>
        /// 主键自增
        /// </summary>
        [Key]
        public int Id { set; get; }
    }
}
