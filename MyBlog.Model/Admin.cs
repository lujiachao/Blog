using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Model
{
    /// <summary>
    /// 管理员表
    /// </summary>
    [Table("AdminUser")]
    public class Admin : BaseModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { set; get; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// 用户密码 
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
    }
}
