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
    public class UserFunctionRelationSql
    {
        string connstr = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ToString();
        /// <summary>
        /// 获取全部功能信息
        /// </summary>
        /// <returns></returns>
        public List<UserFunctionRelationModel> getAllUserFunctionRelationData()
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;//设置命令对象连接属性
            string sql = "select * from User_Function_Relation";//获取目标数据库所有表名
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                List<UserFunctionRelationModel> result = new List<UserFunctionRelationModel>();
                while (dr.Read())
                {
                    UserFunctionRelationModel item = new UserFunctionRelationModel();
                    item.Id = dr["Id"].ToString();
                    item.UserId = dr["UserId"].ToString();
                    item.FunctionId = dr["FunctionId"].ToString();
                    result.Add(item);
                }
                dr.Close();
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                WriteLog.WriteError(ex.ToString());
                dr.Close();
                conn.Close();
                return new List<UserFunctionRelationModel>();
            }
        }
        /// <summary>
        /// 通过用户Id获取他的功能信息
        /// </summary>
        /// <returns></returns>
        public List<UserFunctionRelationModel> getUserFunctionRelationDataByUserId(string UserId)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;//设置命令对象连接属性
            string sql = "select * from User_Function_Relation where 1=1";//获取目标数据库所有表名
            string condition = string.Format(" and UserId='{0}'", UserId);
            sql += condition;
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                List<UserFunctionRelationModel> result = new List<UserFunctionRelationModel>();
                while (dr.Read())
                {
                    UserFunctionRelationModel item = new UserFunctionRelationModel();
                    item.Id = dr["Id"].ToString();
                    item.UserId = dr["UserId"].ToString();
                    item.FunctionId = dr["FunctionId"].ToString();
                    result.Add(item);
                }
                dr.Close();
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                WriteLog.WriteError(ex.ToString());
                dr.Close();
                conn.Close();
                return new List<UserFunctionRelationModel>();
            }
        }
    }
}
