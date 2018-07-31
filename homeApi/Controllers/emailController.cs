using service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace homeApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class emailController : ApiController
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="emailAddress">收件人地址</param>
        /// <param name="title">标题</param>
        /// <param name="text">正文</param>
        /// <param name="Imagefilename">图片路径</param>
        /// <returns></returns>
        [HttpGet]
        [Route("homeApi/email/sendMailToUser")]
        [ActionName("sendMailToUser")]
        public string sendMailToUser(string emailAddress, string title, string text,string Imagefilename="")
        {
            emailService service = new emailService();
            if (service.sendMailToUser(emailAddress, title, text, Imagefilename))
            {
                return "发送成功！";
            }
            else {
                return "发送失败！";
            }
        }
    }
}
