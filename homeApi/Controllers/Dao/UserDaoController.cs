using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using service;
using Model;
using service.DAO;

namespace homeApi.Controllers.Dao
{
    /// <summary>
    /// 用户操作控制器
    /// </summary>
    public class UserDaoController : ApiController
    {
        /// <summary>
        /// 登录判断
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns>1--成功，0--系统错误，-1--查无此用户，-2--用户没有分配任何功能权限，-3--密码错误，-4--用户状态为已删除</returns>
        [HttpGet]
        [Route("homeApi/userDao/loginRequest/{UserName}/{Password}")]
        [ActionName("loginRequest")]
        public int loginRequest(string UserName,string Password)
        {
            UserDaoService udService = new UserDaoService();
            return udService.loginRequest(UserName , Password);
        }
    }
}
