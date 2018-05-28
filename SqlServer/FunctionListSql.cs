using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BaseTools;
using System.Data.SqlClient;

namespace SqlServer
{
    public class FunctionListSql
    {
        string connstr = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ToString();
        /// <summary>
        /// 获取全部功能信息
        /// </summary>
        /// <returns></returns>
        public List<FunctionListModel> getAllFunctionData()
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;//设置命令对象连接属性
                string sql = "select * from FunctionList";//获取目标数据库所有表名
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();
                List<FunctionListModel> result = new List<FunctionListModel>();
                while (dr.Read())
                {
                    FunctionListModel item = new FunctionListModel();
                    item.FunctionId= dr["FunctionId"].ToString();
                    item.FunctionName = dr["FunctionName"].ToString();
                    item.FunctionCode = dr["FunctionCode"].ToString();
                    result.Add(item);
                }
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                WriteLog.WriteError(ex.ToString());
                conn.Close();
                return new List<FunctionListModel>();
            }
        }
    }
}
