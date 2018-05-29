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
                    item.Status = dr["Status"].ToString();
                    item.ImgPath = dr["ImgPath"].ToString();
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
                string sql = "insert into Express_Info  (ExpressId,Company,PhoneNum,Address,Status) values(@ExpressId,@Company,@PhoneNum,@Address,@Status)";
                cmd.Parameters.Add("@ExpressId", SqlDbType.VarChar).Value = expressInfo.ExpressId;
                cmd.Parameters.Add("@Company", SqlDbType.VarChar).Value = expressInfo.Company;
                cmd.Parameters.Add("@PhoneNum", SqlDbType.VarChar).Value = expressInfo.PhoneNum;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = expressInfo.Address;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = expressInfo.Status;
                cmd.Parameters.Add("@ImgPath", SqlDbType.VarChar).Value = expressInfo.ImgPath;
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


//#region 插入操作
///// <summary>
///// 插入
///// </summary>
///// <param name="order"></param>
///// <returns></returns>
//public LamsWorkOrder Insert(LamsWorkOrder order)
//{
//    try
//    {
//        string sqlCmd = @"INSERT INTO [WORK_ORDER_LIST](
//                                   [OBJECT_ID]
//                                  ,[SEND_TYPE]
//                                  ,[BUSSINESS_TYPE]
//                                  ,[SEND_DETAIL]
//                                  ,[CREATE_TIME]
//                                  ,[CREATE_USER]
//                                  ,[ORDER_REMARK]
//                                  ,[TARGET_GROUPS]
//                                  ,[TARGET_USERS]
//                                  ,[ORDER_STATE] ) VALUES (
//                                   @OBJECT_ID
//                                  ,@SEND_TYPE
//                                  ,@BUSSINESS_TYPE
//                                  ,@SEND_DETAIL
//                                  ,@CREATE_TIME
//                                  ,@CREATE_USER
//                                  ,@ORDER_REMARK
//                                  ,@TARGET_GROUPS
//                                  ,@TARGET_USERS
//                                  ,@ORDER_STATE)
//                                   SELECT @@IDENTITY ";
//        using (var cmd = Database.GetSqlStringCommand(sqlCmd))
//        {
//            Database.AddInParameter(cmd, "@OBJECT_ID", DbType.Int32, order.ObjectId);
//            Database.AddInParameter(cmd, "@SEND_TYPE", DbType.Int32, order.SendType);
//            Database.AddInParameter(cmd, "@BUSSINESS_TYPE", DbType.Int32, order.BusinessType);
//            Database.AddInParameter(cmd, "@SEND_DETAIL", DbType.String, order.SendDetail);
//            Database.AddInParameter(cmd, "@CREATE_TIME", DbType.DateTime, order.CreateTime);
//            Database.AddInParameter(cmd, "@CREATE_USER", DbType.Int32, order.CreateUser);
//            Database.AddInParameter(cmd, "@ORDER_REMARK", DbType.String, order.OrderRemark);
//            Database.AddInParameter(cmd, "@TARGET_GROUPS", DbType.String, order.TargetGroups);
//            Database.AddInParameter(cmd, "@TARGET_USERS", DbType.String, order.TargetUsers);
//            Database.AddInParameter(cmd, "@ORDER_STATE", DbType.Int32, order.OrderState);
//            order.OrderId = ExecuteScalar<int>(cmd);
//            return order;
//        }
//    }
//    catch (Exception ex)
//    {

//        LogManager.Get().Throw(ex);
//        return null;
//    }
//}
//#endregion