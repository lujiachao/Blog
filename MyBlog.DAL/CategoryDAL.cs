using MyBlog.Model;
using MyDapper.SqlPower;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyBlog.DAL
{
    public partial class CategoryDAL : BaseDAL<Category>
    {
        //根据pbh生成下级的bh,自动+1,超过限制则返回文本
        public async Task<string> GenBH(string pbh, int x)
        {
            string sql = $"select right(max(bh),{ x.ToString() }) from {_category} where pbh= {pbh}";
            string res = await ExecuteScalarAsync<string>(sql, null);
            if (string.IsNullOrEmpty(res))
            {
                int a = 1;
                if (pbh != "0")
                {
                    return pbh + a.ToString("d" + x);
                }
                return a.ToString("d" + x);
            }
            else
            {
                int a = int.Parse(res) + 1;
                int b = (int)Math.Pow(10, x);
                if (a >= b)
                {
                    throw new Exception("编号超过限制!");
                }
                if (pbh != "0")
                {
                    return pbh + a.ToString("d" + x);
                }
                return a.ToString("d" + x);
            }
        }

        //新增
        public async Task<int> Insert(Category m) => await InsertAsync(m, "");

        //取所有分类的数据拼成json字符串返回
        public async Task<string> GetTreeJson()
        {
            List<TreeNode_LayUI> list_return = new List<TreeNode_LayUI>();
            List<Category> list = await GetList("");
            var top = list.Where(a => a.Pbh == "0");
            foreach (var item in top)
            {
                TreeNode_LayUI node = new TreeNode_LayUI() { Id = item.Id, name = item.CaName, spread = true, pid = 0, };
                var sub = list.Where(a => a.Pbh == item.Bh);
                List<TreeNode_LayUI> list_sub = new List<TreeNode_LayUI>();
                foreach (var item2 in sub)
                {
                    TreeNode_LayUI node2 = new TreeNode_LayUI() { Id = item2.Id, name = item2.CaName, spread = true, pid = item.Id, };
                    list_sub.Add(node2);
                }
                node.children = list_sub;

                list_return.Add(node);
            }
            return JsonConvert.SerializeObject(list_return);
        }

        /// <summary>
        /// 根据分类编号取实体类
        /// </summary>
        /// <param name="caBh"></param>
        /// <returns></returns>
        public async Task<Category> GetModelByBh(string caBh)
        {

            var m = await QueryOneAsync<Category>($"select * from {_category} where bh=@bh order by desc limit 1",

              new { bh = caBh });
            return m;
        }

        //删除
        public async Task<bool> Delete(int id) => await DeleteAsync(id);

        //查询
        public async Task<List<Category>> GetList(string cond)
        {
            string sql = $"select * from {_category}";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += $" where {cond}";
            }
            var list = await QueryAsync<Category>(sql, null);
            return list.ToList();
        }

        //获取实体类
        public async Task<Category> GetModel(int id) => await FindByIDAsync(id);

        //修改
        public async Task<bool> Update(Category m) => await UpdateAsync(m);

        //计算记录数
        public async Task<int> CalcCount(string cond)
        {
            string sql = $"select count(1) from {_category}";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += $" where {cond}";
            }
            int res = await ExecuteScalarAsync<int>(sql, null);
            return res;
        }
    }
}
