using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using service;

namespace homeApi.Tests
{
    [TestClass]
    public class emailTest
    {
        [TestMethod]
        [Description("测试发送邮件功能")]
        [TestCategory("emailController")]
        public void TestSendMailToUser()
        {
            emailService service = new emailService();
            string emailAddress = "815473772@qq.com";
            string title = "hello lumi!";
            string text = "Hello! Here is a pic!";
            string Imagefilename = "D:/web_deployment/home/homeApi/homeApi/Upload/BodyPart_a8d1f1b5-da37-483b-9202-8c0fa74b5112";
            if (service.sendMailToUser(emailAddress, title, text, Imagefilename))
            {
            }
            else
            {
            }
        }
    }
}
