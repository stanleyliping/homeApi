using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace SqlServer
{

    public class UserInfoSql
    {
        ConnectionStringSettingsCollection sss = ConfigurationManager.ConnectionStrings;
        string connstr = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ToString();

        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfoModel> getAllUserInfoData() {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;//设置命令对象连接属性
                string sql = "select * from User_Info";//获取目标数据库所有表名
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();
                List<UserInfoModel> result = new List<UserInfoModel>();
                while (dr.Read())
                {
                    UserInfoModel item = new UserInfoModel();
                    item.UserId = dr[0].ToString();
                    item.Name = dr[1].ToString();
                    item.Password = dr[2].ToString();
                    item.MobileNum = dr[3].ToString();
                    item.Email = dr[4].ToString();
                    item.Gender = dr[5].ToString();
                    item.Status = dr[6].ToString();
                    item.CreateTime = dr[7].ToString();
                    item.UpdateTime = dr[8].ToString();
                    item.wechatId = dr[9].ToString();
                    result.Add(item);
                }
                return result;
            }
            catch (Exception ex) {
                return new List<UserInfoModel>();
            }
        }
        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        public UserInfoModel getUserInfoDataByUserName(string userName)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;//设置命令对象连接属性
                string sql = "select * from User_Info where 1=1";//获取目标数据库所有表名
                string condition = string.Format(" and Name='{0}'", userName);
                sql += condition;
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();
                UserInfoModel result = new UserInfoModel();
                if (dr.Read())
                {
                    UserInfoModel item = new UserInfoModel();
                    item.UserId = dr[0].ToString();
                    item.Name = dr[1].ToString();
                    item.Password = dr[2].ToString();
                    item.MobileNum = dr[3].ToString();
                    item.Email = dr[4].ToString();
                    item.Gender = dr[5].ToString();
                    item.Status = dr[6].ToString();
                    item.CreateTime = dr[7].ToString();
                    item.UpdateTime = dr[8].ToString();
                    item.wechatId = dr[9].ToString();
                    result =(item);
                }
                else {
                    result = new UserInfoModel();
                }
                return result;
            }
            catch (Exception ex)
            {
                return new UserInfoModel();
            }

        }
    }
}
