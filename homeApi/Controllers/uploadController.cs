using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using service;
using service.Functions;
using BaseTools;

namespace homeApi.Controllers
{
    /// <summary>
    /// 上传文件并保存接口（直接调用无效）
    /// </summary>
    public class uploadController : ApiController
    {
        /// <summary>
        /// 上传文件并保存接口（直接调用无效）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("homeApi/upload/uploadImgAndORC")]
        [ActionName("uploadImgAndORC")]
        public async Task<object> uploadImgAndORC()
        {
            HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];//获取传统context  
            HttpRequestBase request = context.Request;//定义传统request对象,request["name"]
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string uploadFolderPath = HostingEnvironment.MapPath("~/Upload");

            //如果路径不存在，创建路径  
            if (!Directory.Exists(uploadFolderPath))
                Directory.CreateDirectory(uploadFolderPath);

            List<string> files = new List<string>();
            var provider = new MultipartFormDataStreamProvider(uploadFolderPath);
            try
            {
                // Read the form data.  
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.  

                foreach (var file in provider.FileData)
                {//接收文件  
                    files.Add(Path.GetFileName(file.LocalFileName));
                }
                ORCService service = new ORCService();
                var result=service.ORCImg(HostingEnvironment.MapPath("~/Upload")+"/"+string.Join(",", files));
                return result;
            }
            catch(Exception ex)
            {
                WriteLog.WriteError(ex.ToString());
                return "";
            }
        }
    }
}
