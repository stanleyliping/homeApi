using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.Functions
{
    public class ORCService
    {
        static string APP_ID = "11262645";
        static string API_KEY = "AURLtjXATLdto6snRBScuHmU";
        static string SECRET_KEY = "P0BsfZNHKIMICmPZ9zFQnOyRcd7NY4lS";
        static Baidu.Aip.Ocr.Ocr client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);

        /// <summary>
        /// 图像文字识别并返回
        /// </summary>
        /// <param name="imgCode">图像的base64码</param>
        /// <returns></returns>
        public object ORCImg(string imgCode) {
            
            var image =File.ReadAllBytes(imgCode);
            var json = client.GeneralBasic(image);
            var result = json.ToString();
            return json;
        }
    }
}
