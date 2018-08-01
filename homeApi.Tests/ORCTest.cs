using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using service;
using service.Functions;

namespace homeApi.Tests
{
    [TestClass]
    public class ORCTest
    {
        [TestMethod]
        [Description("测试获取全部用户信息")]
        [TestCategory("userInfoController")]
        public void TestORC() {
            string imgPath = "D:/web_deployment/home/homeApi/homeApi/Upload/12345.jpg";
            ORCService service = new ORCService();
            var result=service.ORCImg(imgPath);
        }
    }
}
