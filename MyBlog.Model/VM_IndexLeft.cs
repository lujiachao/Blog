using Dapper.Contrib.Extensions;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Model
{
    /// <summary>
    /// 首页左边的相应视图类
    /// </summary>
    [Table("VM_IndexLeft")]
    public class VM_IndexLeft : BaseModel
    {
        public string bh { set; get; }
        public string caname { set; get; }
        public string count { set; get; }
    }
}
