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
    public class UserInfoService
    {
        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfoModel> getAllUserInfo()
        {
            UserInfoSql userinfosql = new UserInfoSql();
            return userinfosql.getAllUserInfoData();
        }
        /// <summary>
        /// 通过用户姓名获取用户信息
        /// </summary>
        /// <param name="userName">用户姓名</param>
        /// <returns></returns>
        public UserInfoModel getUserInfoByUserName(string userName)
        {
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");//处理跨域问题
            UserInfoSql userinfosql = new UserInfoSql();
            return userinfosql.getUserInfoDataByUserName(userName);
        }
    }
}
