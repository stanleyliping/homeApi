using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfoModel
    {
        public string UserId { set; get; }
        public string Name { set; get; }
        public string Password { set; get; }
        public string MobileNum { set; get; }
        public string Email { set; get; }
        public string Gender { set; get; }//1-男，2-女
        public string Status { set; get; }//1-激活，2-禁用
        public string wechatId { set; get; }
        public string CreateTime { set; get; }
        public string UpdateTime { set; get; }
    }
}
