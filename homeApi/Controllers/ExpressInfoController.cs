using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using service;
using Model;
using System.Threading.Tasks;
using BaseTools;
using System.Web;
using System.Web.Hosting;
using System.IO;
using Newtonsoft.Json;

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
        /// 通过表单插入一条快递信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("homeApi/expressInfo/insertExpressInfoWithImg")]
        [ActionName("insertExpressInfoWithImg")]
        public async Task<ExpressInfoModel>  insertExpressInfo()
        {
            try {
                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context  
                HttpRequestBase request = context.Request;//定义传统request对象,request["name"]
                var expressInfoJSON = "";
                ExpressInfoModel result = new ExpressInfoModel();
                try {
                    expressInfoJSON = request["expressInfo"];
                    result=JsonConvert.DeserializeObject<ExpressInfoModel>(expressInfoJSON);
                }
                catch (Exception ex)
                {
                    WriteLog.WriteError(ex.ToString());
                    return new ExpressInfoModel();
                }

                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);//415
                }
                string uploadFolderPath = HostingEnvironment.MapPath("~/Upload");

                //如果路径不存在，创建路径  
                if (!Directory.Exists(uploadFolderPath))
                    Directory.CreateDirectory(uploadFolderPath);

                string files = "";
                var provider = new MultipartFormDataStreamProvider(uploadFolderPath);
                try
                {
                    // Read the form data.  
                    await Request.Content.ReadAsMultipartAsync(provider);

                    // This illustrates how to get the file names.  

                    foreach (var file in provider.FileData)
                    {//接收文件  
                        files=Path.GetFileName(file.LocalFileName);
                    }
                }
                catch (Exception ex)
                {
                    WriteLog.WriteError(ex.ToString());
                }
                result.ImgPath = files;
                return result;
            }
            catch (Exception ex) {
                WriteLog.WriteError(ex.ToString());
                return new ExpressInfoModel();
            }
        }
    }
}
