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
    /// 快递信息控制器
    /// </summary>
    public class ExpressInfoController : ApiController
    {
        /// <summary>
        /// 获取全部快递信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("homeApi/expressInfo/getAllExpressInfo")]
        [ActionName("getAllExpressInfo")]
        public IEnumerable<ExpressInfoModel> getAllExpressInfo()
        {
            ExpressInfoService service = new ExpressInfoService();
            List<ExpressInfoModel> list = new List<ExpressInfoModel>();
            list = service.getAllExpressInfo();
            return list;
        }

        /// <summary>
        /// 插入一条快递信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("homeApi/expressInfo/insertExpressInfo")]
        [ActionName("insertExpressInfo")]
        public ExpressInfoModel insertExpressInfo(ExpressInfoModel  expressInfo)
        {
            ExpressInfoService service = new ExpressInfoService();
            ExpressInfoModel result = new ExpressInfoModel();
            result = service.insertExpressInfo(expressInfo);
            return result;
        }
    }
}
