using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using SqlServer;
using Model;

namespace service
{
    public class FunctionListService
    {
        /// <summary>
        /// 获取全部功能信息
        /// </summary>
        /// <returns></returns>
        public List<FunctionListModel> getAllFunctions()
        {
            FunctionListSql functionSql = new FunctionListSql();
            return functionSql.getAllFunctionData();
        }
    }
}
