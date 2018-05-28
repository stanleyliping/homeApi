using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserFunctionRelationModel
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { set; get; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { set; get; }
        /// <summary>
        /// 功能Id
        /// </summary>
        public string FunctionId { set; get; }
    }
}
