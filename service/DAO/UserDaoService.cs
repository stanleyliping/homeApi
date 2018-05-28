using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using SqlServer;
using Model;
using BaseTools;

namespace service.DAO
{
    public class UserDaoService
    {
        /// <summary>
        ///  判断登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>1--成功，0--系统错误，-1--查无此用户，-2--用户没有分配任何功能权限，-3--密码错误，-4--用户状态为已删除</returns>
        public int loginRequest(string userName,string password)
        {
            UserInfoService uiService = new UserInfoService();
            FunctionListService flService = new FunctionListService();
            UserFunctionRelationService ufrService = new UserFunctionRelationService();
            try {
                var userInfo = uiService.getUserInfoByUserName(userName);
                if (userInfo.UserId==null)
                {//查无此用户
                    return -1;
                }
                if (userInfo.Status.Equals("1"))
                {//用户处于激活状态
                    if (userInfo.Password.Equals(password))
                    {//密码匹配正确
                        var allUserFunctionRelation = ufrService.getUserFunctionRelationByUserId(userInfo.UserId);//获取该用户拥有的权限
                        if (allUserFunctionRelation.Count() > 0)
                        {//用户拥有至少一个权限
                            return 1;
                        }
                        else
                        {//用户没有分配任何功能权限
                            return -2;
                        }
                    }
                    else
                    {//密码错误
                        return -3;
                    }
                }
                else
                {//用户状态为已删除
                    return -4;
                }
            }
            catch (Exception ex) {
                WriteLog.WriteError(ex.ToString());
                return 0;
            }
            
        }
    }
}
