using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Model
{
    [Table("Category")]
    public class Category : BaseModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { set; get; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CaName { set; get; }
        /// <summary>
        /// 分类编号 
        /// </summary>
        public string Bh { set; get; }
        /// <summary>
        /// 父编号
        /// </summary>
        public string Pbh { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
    }
}
