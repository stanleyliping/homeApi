using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using service;
using Model;

namespace homeApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class FunctionListController : ApiController
    {
        /// <summary>
        /// 获取全部功能信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("homeApi/function/getAllFunctions")]
        [ActionName("getAllFunctions")]
        public IEnumerable<FunctionListModel> getAllFunctions()
        {
            FunctionListService service = new FunctionListService();
            List<FunctionListModel> list = new List<FunctionListModel>();
            list = service.getAllFunctions();
            return list;
        }
    }
}
