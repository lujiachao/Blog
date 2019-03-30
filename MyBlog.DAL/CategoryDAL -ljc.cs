using MyBlog.Model;
using MyDapper.SqlPower;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.DAL
{
    // 分类表的数据库操作类
    public partial class CategoryDAL : BaseDAL<Category>
    {
        public static string _vm_IndexLeft = EntityHelper.CallName<VM_IndexLeft>();

        public static string _category = EntityHelper.CallName<Category>();

        public static string _blog = EntityHelper.CallName<Blog>();

        // 取首页左边的分类及分类文章数量
        public async Task<List<VM_IndexLeft>> GetIndexLeft_Ca()
        {
            string sql = $"select category.bh,category.caname,count(1) as count from {_category} A " +
                        $"inner join {_blog} B on A.bh = B.cabh " +
                        "where pbh = '01' " +
                        "group by A.bh,A.caname";
            var result = await QueryAsync<VM_IndexLeft>(sql, null);
            return result.ToList();
        }

        // 取首页左边的月份及月份文章数量
        public async Task<List<VM_IndexLeft>> GetIndexLeft_Month()
        {
            string sql = "select DATE_FORMAT(createdate,'%Y-%m') as bh,count(1) as count " +
                            $"from {_blog} " +
                            "group by bh " +
                            "order by bh desc; ";
            var result = await QueryAsync<VM_IndexLeft>(sql, null);
            return result.ToList();
        }
    }
}
