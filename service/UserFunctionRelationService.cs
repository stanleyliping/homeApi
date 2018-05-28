using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using SqlServer;
using Model;

namespace service
{
    public class UserFunctionRelationService
    {
        /// <summary>
        /// 获取全部用户功能关系信息
        /// </summary>
        /// <returns></returns>
        public List<UserFunctionRelationModel> getAllUserFunctionRelation()
        {
            UserFunctionRelationSql userFunctionRelationSql = new UserFunctionRelationSql();
            return userFunctionRelationSql.getAllUserFunctionRelationData();
        }


        /// <summary>
        /// 获取全部用户功能关系信息
        /// </summary>
        /// <returns></returns>
        public List<UserFunctionRelationModel> getUserFunctionRelationByUserId(string UserId)
        {
            UserFunctionRelationSql userFunctionRelationSql = new UserFunctionRelationSql();
            return userFunctionRelationSql.getUserFunctionRelationDataByUserId(UserId);
        }
    }
}
