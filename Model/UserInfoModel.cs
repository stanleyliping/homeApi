using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfoModel
    {
        /// <summary>
        /// id
        /// </summary>
        public string UserId { set; get; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { set; get; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MobileNum { set; get; }
        /// <summary>
        /// email地址
        /// </summary>
        public string Email { set; get; }
        /// <summary>
        /// 性别 1-男，2-女
        /// </summary>
        public string Gender { set; get; }
        /// <summary>
        /// 状态 1-激活，2-禁用
        /// </summary>
        public string Status { set; get; }
        /// <summary>
        /// 在微信企业号中的用户id
        /// </summary>
        public string wechatId { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { set; get; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public string UpdateTime { set; get; }
    }
}
