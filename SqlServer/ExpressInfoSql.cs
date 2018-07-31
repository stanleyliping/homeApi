using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using BaseTools;
using System.Data;

namespace SqlServer
{
    public class ExpressInfoSql
    {
        string connstr = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ToString();

        /// <summary>
        /// 获取全部快递信息
        /// </summary>
        /// <returns></returns>
        public List<ExpressInfoModel> getAllExpressInfoData()
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;//设置命令对象连接属性
                string sql = "select * from Express_Info";//获取目标数据库所有表名
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();
                List<ExpressInfoModel> result = new List<ExpressInfoModel>();
                while (dr.Read())
                {
                    ExpressInfoModel item = new ExpressInfoModel();
                    item.RowId = dr["RowId"].ToString();
                    item.ExpressId = dr["ExpressId"].ToString();
                    item.Company = dr["Company"].ToString();
                    item.PhoneNum = dr["PhoneNum"].ToString();
                    item.Address = dr["Address"].ToString();
                    item.Status = int.Parse(dr["Status"].ToString());
                    item.ImgPath = dr["ImgPath"].ToString();
                    item.ExpressCode=dr["ExpressCode"].ToString();
                    result.Add(item);
                }
                dr.Close();
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                conn.Close();
                WriteLog.WriteError(ex.ToString());
                return new List<ExpressInfoModel>();
            }
        }

        /// <summary>
        /// 增加快递信息
        /// </summary>
        /// <returns></returns>
        public ExpressInfoModel insertExpressInfo(ExpressInfoModel expressInfo)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;//设置命令对象连接属性
                string sql = "insert into Express_Info  (ExpressId,Company,PhoneNum,Address,Status,ImgPath,ExpressCode) values(@ExpressId,@Company,@PhoneNum,@Address,@Status,@ImgPath,@ExpressCode)";
                cmd.Parameters.Add("@ExpressId", SqlDbType.VarChar).Value = expressInfo.ExpressId;
                cmd.Parameters.Add("@Company", SqlDbType.VarChar).Value = expressInfo.Company;
                cmd.Parameters.Add("@PhoneNum", SqlDbType.VarChar).Value = expressInfo.PhoneNum;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = expressInfo.Address;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = expressInfo.Status;
                cmd.Parameters.Add("@ImgPath", SqlDbType.VarChar).Value = expressInfo.ImgPath;
                cmd.Parameters.Add("@ExpressCode", SqlDbType.VarChar).Value = expressInfo.ExpressCode;
                cmd.CommandText = sql;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
                conn.Close();
                return expressInfo;
            }
            catch (Exception ex)
            {
                conn.Close();
                WriteLog.WriteError(ex.ToString());
                return new ExpressInfoModel();
            }

        }
    }
}