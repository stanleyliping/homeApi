using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using BaseTools;

namespace SqlServer
{

    public class UserInfoSql
    {
        //ConnectionStringSettingsCollection sss = ConfigurationManager.ConnectionStrings;
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
                    item.UserId = dr["UserId"].ToString();
                    item.Name = dr["Name"].ToString();
                    item.Password = dr["Password"].ToString();
                    item.MobileNum = dr["MobileNum"].ToString();
                    item.Email = dr["Email"].ToString();
                    item.Gender = dr["Gender"].ToString();
                    item.Status = dr["Status"].ToString();
                    item.CreateTime = dr["CreateTime"].ToString();
                    item.UpdateTime = dr["UpdateTime"].ToString();
                    item.WechatId = dr["wechatId"].ToString();
                    item.IdentyGuid= dr["IdentyGuid"].ToString();
                    result.Add(item);
                }
                return result;
            }
            catch (Exception ex) {
                WriteLog.WriteError(ex.ToString());
                return new List<UserInfoModel>();
            }
        }

        /// <summary>
        /// 通过用户姓名获取用户信息
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
                    item.UserId = dr["UserId"].ToString();
                    item.Name = dr["Name"].ToString();
                    item.Password = dr["Password"].ToString();
                    item.MobileNum = dr["MobileNum"].ToString();
                    item.Email = dr["Email"].ToString();
                    item.Gender = dr["Gender"].ToString();
                    item.Status = dr["Status"].ToString();
                    item.CreateTime = dr["CreateTime"].ToString();
                    item.UpdateTime = dr["UpdateTime"].ToString();
                    item.WechatId = dr["wechatId"].ToString();
                    item.IdentyGuid = dr["IdentyGuid"].ToString();
                    result =(item);
                }
                else {
                    result = new UserInfoModel();
                }
                return result;
            }
            catch (Exception ex)
            {
                WriteLog.WriteError(ex.ToString());
                return new UserInfoModel();
            }

        }
    }
}
