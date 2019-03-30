using MyBlog.Model;
using MyDapper.SqlPower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL
{
    public partial class CasevideoDAL : BaseDAL<Casevideo>
    {
        public static string tableName = EntityHelper.CallName<Casevideo>();

        public CasevideoDAL()
        {

        }

        //增加一条数据
        public async Task<int> Add(Casevideo model) => await InsertAsync(model, null);


        //更新一条数据
        public async Task<bool> UpdateOne(Casevideo model) => await UpdateAsync(model);

        //按条件更新数据
        public async Task<bool> UpdateByCond(string str_set, string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"update {tableName} set {str_set} ");
            strSql.Append($" where {cond}");
            var result = await ExecuteAsync(strSql.ToString(), null);
            return result > 0;
        }

        //删除一条数据
        public async Task<bool> Delete(int id) => await DeleteAsync(id);

        //根据条件删除数据
        public async Task<bool> DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"delete from {tableName} ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append($" where {cond}");
            }
            var result = await ExecuteAsync(strSql.ToString(), null);
            return result > 0;
        }

        //取一个字段的值
        public async Task<string> GetOneFiled(string filed, string cond)
        {
            string sql = $"select {filed} from {tableName}";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += $" where {cond}";
            }
            var result = await ExecuteScalarAsync<string>(sql, null);
            return result;
        }

        //得到一个对象实体
        public async Task<Casevideo> GetModel(int id) => await FindByIDAsync(id);

        //根据一个条件得到一个对象实体
        public async Task<Casevideo> GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"select * from {tableName} ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append($" where {cond}");
            }
            strSql.Append(" limit 1;");
            var result = await QueryOneAsync<Casevideo>(strSql.ToString(), null);
            return result;
        }

        //获得数据列表
        public async Task<List<Casevideo>> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append($" FROM {tableName} ");
            if (strWhere.Trim() != "")
            {
                strSql.Append($" where {strWhere}");
            }
            var result = await QueryAsync<Casevideo>(strSql.ToString(), null);
            return result.ToList();
        }

        //分页获取数据列表
        public async Task<List<Casevideo>> GetListArray(string fileds, string orderstr, int PageSize, int PageIndex, string strWhere)
        {
            string cond = string.IsNullOrEmpty(strWhere) ? "" : string.Format(" where {0}", strWhere);

            string sql = string.Format("select {0} from `{1}` {2} order by {3} limit {4},{5}", fileds, tableName, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);
            var result = await QueryAsync<Casevideo>(sql.ToString(), null);
            return result.ToList();
        }

        //计算记录数
        public async Task<int> CalcCount(string cond)
        {
            string sql = $"select count(1) from {tableName}";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += $" where cond" ;
            }
            var result = await ExecuteScalarAsync<int>(sql, null);
            return result;
        }
    }
}
