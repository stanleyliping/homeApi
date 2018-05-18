using service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace homeApi.Controllers
{
    public class emailController : ApiController
    {

        [HttpGet]
        [Route("homeApi/email/sendMailToUser")]
        [ActionName("sendMailToUser")]
        public string sendMailToUser(string emailAddress, string title, string text)
        {
            emailService service = new emailService();
            if (service.sendMailToUser(emailAddress, title, text))
            {
                return "发送成功！";
            }
            else {
                return "发送失败！";
            }
        }

        // GET: api/email/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/email
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/email/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/email/5
        public void Delete(int id)
        {
        }
    }
}
