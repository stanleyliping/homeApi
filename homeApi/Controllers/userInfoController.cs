using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using service;
using Model;

namespace homeApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class userInfoController : ApiController
    {
        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("homeApi/userInfo/getAllUserInfo")]
        [ActionName("getAllUserInfo")]
        public IEnumerable<UserInfoModel> getAllUserInfo()
        {
            UserInfoService service = new UserInfoService();
            List<UserInfoModel> list = new List<UserInfoModel>();
            list=service.getAllUserInfo();
            return list;
        }
        /// <summary>
        /// 通过用户姓名获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        [HttpGet]
        [Route("homeApi/userInfo/getUserInfoByName/{userName}")]
        [ActionName("getUserInfoByName")]
        public UserInfoModel getUserInfoByUserName(string userName)
        {
            UserInfoService service = new UserInfoService();
            UserInfoModel userInfo = new UserInfoModel();
            userInfo = service.getUserInfoByUserName(userName);
            return userInfo;
        }


        /// <summary>
        /// post方法
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Put方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]string value)
        {
        }

       /// <summary>
       /// delete方法
       /// </summary>
       /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}