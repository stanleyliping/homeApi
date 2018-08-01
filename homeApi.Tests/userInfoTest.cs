using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using service;
using System.Configuration;

namespace homeApi.Tests
{
    [TestClass]
    public class userInfoTest
    {
        [TestMethod]
        [Description("测试获取全部用户信息")]
        [TestCategory("userInfoController")]
        public void TestGetAllUserInfo()
        {
            UserInfoService service = new UserInfoService();
            if (service.getAllUserInfo().Count>0)
            {
                var result = service.getAllUserInfo();
            }
            else
            {
            }
        }
    }
}
