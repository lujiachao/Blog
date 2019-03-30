using MyBlog.Model;
using MyDapper.SqlPower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL
{
    public class BlogDAL : BaseDAL<Blog>
    {
        public static string tableName = EntityHelper.CallName<Admin>();
        // 新增一条数据
        public async Task<int> AddOne(Blog blog) => await InsertAsync(blog, "");

        //更新一条数据
        public async Task<bool> UpdateOne(Blog blog) => await UpdateAsync(blog);

        //按条件更新数据
        public async Task<bool> UpdateByCond(string str_set, string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"update {tableName} set {str_set} ");
            strSql.Append($"where {cond}");
            var result = await ExecuteAsync( strSql.ToString() , null);
            return result > 0 ? true : false;
        }

        //删除一条数据
        public async Task<bool> DeleteBlogById(int id) => await DeleteAsync(id);

        //根据条件删除数据
        public async Task<bool> DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"delete from {tableName} ");
            if (!string.IsNullOrWhiteSpace(cond))
            {
                strSql.Append($" where {cond}" );
            }
            var reslut = await ExecuteAsync( strSql.ToString() , null);
            return reslut > 0 ? true : false;
    
        }

        //取blog表 取一个字段的值
        public async Task<string> GetOneFiled(string filed, string cond)
        {
            string sql = $"select {filed} from {tableName} ";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += $" where {cond}";
            }
            var result = await ExecuteScalarAsync<string>(sql.ToString() , null);
            return result;
        }

        //获得blog表单条数据实体
        public async Task<Blog> GetModel(int id) => await FindByIDAsync(id);

        //根据条件获得一个对象实体,获取单条数据
        public async Task<Blog> GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"select * from {tableName} ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append($" where {cond}" );
            }
            strSql.Append(" limit 1;");
            return await QueryOneAsync<Blog>(strSql.ToString(), null);
        }

        //获取数据列表
        public async Task<List<Blog>> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append($" FROM {tableName} ");
            if (strWhere.Trim() != "")
            {
                strSql.Append($" where {strWhere}" );
            }
            var result = await QueryAsync<Blog>(strSql.ToString(), null);
            return result.ToList();
        }

        ///分页取数据列表
        public async Task<List<Blog>> GetListArray(string fileds, string orderstr, int PageSize, int PageIndex, string strWhere)
        {
            string cond = string.IsNullOrEmpty(strWhere) ? string.Empty : string.Format(" where {0}", strWhere);
            string sql = string.Format($"select {0} from {tableName} {1} order by {2} limit {3},{4}", fileds, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);
            var result = await QueryAsync<Blog>(sql.ToString(), null);
            return result.ToList();
        }

        //计算计数器
        public async Task<int> CalcCount(string cond)
        {
            string sql = "select count(1) from {tableName}";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            return await ExecuteScalarAsync<int>(sql, null);
        }
    }
}
