using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ExpressInfoModel
    {
        /// <summary>
        /// id
        /// </summary>
        public string RowId { set; get; }
        /// <summary>
        /// 快递编号
        /// </summary>
        public string ExpressId { set; get; }
        /// <summary>
        /// 快递公司
        /// </summary>
        public string Company { set; get; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string PhoneNum { set; get; }
        /// <summary>
        /// 取快递地址
        /// </summary>
        public string Address { set; get; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { set; get; }
        /// <summary>
        /// 截图路径
        /// </summary>
        public string ImgPath { set; get; }
        /// <summary>
        /// 取件码
        /// </summary>
        public string ExpressCode { set; get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class sendExpressInfoEmailModel {
        /// <summary>
        /// 
        /// </summary>
       public List<string> receiverEmailList { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public ExpressInfoModel expressInfo { set; get; }
    }
}
