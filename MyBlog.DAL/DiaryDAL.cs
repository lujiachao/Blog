using MyBlog.Model;
using MyDapper.SqlPower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL
{
    public class DiaryDAL : BaseDAL<Diary>
    {
        public static string _diary = EntityHelper.CallName<Diary
            >();

        //增加一条数据
        public async Task<int> Add(Diary diary) => await InsertAsync(diary, "");

        //更新一条数据
        public async Task<bool> Update(Diary diary) => await UpdateAsync(diary);

        //按条件更新
        public async Task<bool> UpdateByCond(string str_set, string cond)
        {
            string commandText = $"Update {_diary} set {str_set} where {cond}";
            var result = await ExecuteAsync(commandText, null);
            return result > 0;
        }

        //删除一条数据
        public async Task<bool> Delete(int id) => await DeleteAsync(id);

        //根据条件删除数据
        public async Task<bool> DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"delete from {_diary} ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            var result = await ExecuteAsync(strSql.ToString(), null);
            return result > 0;
        }

        //取一个字段的值
        public async Task<string> GetOneFiled(string filed, string cond)
        {
            string sql = $"select {filed} from {_diary}";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += $" where {cond}";
            }

            string tmp = await ExecuteScalarAsync<string>(sql,null);
            return tmp;
        }

        //得到一个对象实体
        public async Task<Diary> GetModel(int id) => await FindByIDAsync(id);

        //根据条件得到一个对象实体
        public async Task<Diary> GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append($"select * from {_diary} ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append($" where {cond}"  );
            }
            strSql.Append(" limit 1;");
            Diary model = null;
            model = await QueryOneAsync<Diary>(strSql.ToString(),null);
            return model;
        }

        //获取数据列表
        public async Task<List<Diary>> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append($" FROM {_diary} ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            var result = await QueryAsync<Diary>(strSql.ToString(), null);
            return result.ToList();
        }

        //分页获取数据列表
        public async Task<List<Diary>> GetListArray(string fileds, string orderstr, int PageSize, int PageIndex, string strWhere)
        {

            string cond = string.IsNullOrEmpty(strWhere) ? "" : string.Format(" where {0}", strWhere);

            string sql = string.Format("select {0} from {1} {2} order by {3} limit {4},{5}", fileds, _diary, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);

            return (await QueryAsync<Diary>(sql, null)).ToList();
        }

        //计算计数器
        public async Task<int> CalcCount(string cond)
        {
            string sql = $"select count(1) from {_diary}";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += $" where {cond}" ;
            }
            int i = await ExecuteScalarAsync<int>(sql,null);
            return i;
        }
    }
}
