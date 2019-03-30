using MyBlog.Model;
using MyDapper.SqlPower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL
{
    public class LogDAL : BaseDAL<Log>
    {
        public static string _log = EntityHelper.CallName<Log
            >();

        //增加一条数据
        public async Task<int> Add(Log model) => await InsertAsync(model,"");

        //更新一条数据
        public async Task<bool> Update(Log model) => await UpdateAsync(model);

        /// <summary>按条件更新数据
        /// 
        /// </summary>
        public async Task<bool> UpdateByCond(string str_set, string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"update {_log} set {str_set}" );
            strSql.Append($" where {cond}" );
            var result = await ExecuteAsync(strSql.ToString(), null);
            return result > 0;
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public async Task<bool> Delete(int id) => await DeleteAsync(id);

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public async Task<bool> DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"delete from {_log} ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append($" where {cond}" );
            }
            var result = await ExecuteAsync(strSql.ToString(), null);
            return result > 0;
        }

        /// <summary>取一个字段的值
        /// 
        /// </summary>
        /// <param name="filed">字段，如sum(je)</param>
        /// <param name="cond">条件，如userid=2</param>
        /// <returns></returns>
        public async Task<string> GetOneFiled(string filed, string cond)
        {
            string sql = $"select {filed} from {_log}";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += $" where {cond}" ;
            }

            return await ExecuteScalarAsync<string>(sql,null);
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public async Task<Log> GetModel(int id) => await FindByIDAsync(id);

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public async Task<Log> GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"select * from {_log} ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1;");
            var result = await QueryOneAsync<Log>(strSql.ToString(), null);
            return result;
        }

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public async Task<List<Log>> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append($" FROM {_log} ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return (await QueryAsync<Log>(strSql.ToString(), null)).ToList();
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public async Task<List<Log>> GetListArray(string fileds, string orderstr, int PageSize, int PageIndex, string strWhere)
        {

            string cond = string.IsNullOrEmpty(strWhere) ? "" : string.Format(" where {0}", strWhere);

            string sql = string.Format("select {0} from {1} {2} order by {3} limit {4},{5}", fileds,_log, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);


            return (await QueryAsync<Log>(sql, null)).ToList();
        }



        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<int> CalcCount(string cond)
        {
            string sql = $"select count(1) from {_log}";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            return await ExecuteScalarAsync<int>(sql, null);
        }
    }
}
