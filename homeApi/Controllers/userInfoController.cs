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
        ///通过用户姓名获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("homeApi/userInfo/getUserInfoByName")]
        [ActionName("getUserInfoByName")]
        public UserInfoModel getUserInfoByUserName(string userName)
        {
            UserInfoService service = new UserInfoService();
            UserInfoModel userInfo = new UserInfoModel();
            userInfo = service.getUserInfoByUserName(userName);
            return userInfo;
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}