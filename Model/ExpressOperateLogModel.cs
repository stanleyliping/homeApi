using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ExpressOperateLogModel
    {
        /// <summary>
        /// id
        /// </summary>
        public string OperateId { set; get; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperateType { set; get; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperateTime { set; get; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OperateUserId { set; get; }
        /// <summary>
        /// 快递主键
        /// </summary>
        public string ExpressRowId { set; get; }
    }
}
