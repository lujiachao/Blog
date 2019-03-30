using MyBlog.Model;
using MyDapper.SqlPower;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL
{
    public class AdminDAL : BaseDAL<Admin>
    {
        public static string tableName = EntityHelper.CallName<Admin>();
        // 新增管理员
        public async Task<int> AddOne(Admin admin) => await InsertAsync(admin, "");

        // 登录       
        public async Task<Admin> Login(string username, string password)
        {
            try
            {
                string sql = $"select * from {tableName} where username = @username and password = @password";
                var admin = await QueryOneAsync<Admin>(sql, new { username, password });
                return admin;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //根据Id获取用户信息
        public async Task<Admin> GetAdminById(int id) => await FindByIDAsync(id);

        // 修改密码
        public async Task<int> UpdatePwd(string pwd, int id)
        {
            string sql = $"update {tableName} set password = @password where Id = @id";
            var result = await ExecuteAsync(sql,new { pwd, id});
            return result;
        }
    }
}
