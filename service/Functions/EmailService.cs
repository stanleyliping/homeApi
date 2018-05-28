using BaseTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class emailService
    {
        /// <summary>
        /// 发送邮件给单个用户
        /// </summary>
        /// <param name="emailAddress">邮箱地址</param>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <returns></returns>
        public bool sendMailToUser(string emailAddress,string title,string text)
        {
            try{
                //实例化一个发送邮件类。
                MailMessage mailMessage = new MailMessage();
                //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
                mailMessage.From = new MailAddress("1416755128@qq.com");
                //收件人邮箱地址。
                mailMessage.To.Add(new MailAddress(emailAddress));
                //邮件标题。
                mailMessage.Subject = title;
                //邮件内容。
                mailMessage.Body = text;

                //实例化一个SmtpClient类。
                SmtpClient client = new SmtpClient();
                //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
                client.Host = "smtp.qq.com";
                //使用安全加密连接。
                client.EnableSsl = true;
                //不和请求一块发送。
                client.UseDefaultCredentials = false;
                //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
                client.Credentials = new NetworkCredential("1416755128@qq.com", "hgaekqhgzsgojfid");
                //发送
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex) {
                WriteLog.WriteError(ex.ToString());
                return false;
            }
           
        }
    }
}
