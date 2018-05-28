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
    public class ExpressInfoService
    {
        public List<ExpressInfoModel> getAllExpressInfo() {
            ExpressInfoSql expressInfoSql = new ExpressInfoSql();
            return expressInfoSql.getAllExpressInfoData();
        }

        public ExpressInfoModel insertExpressInfo(ExpressInfoModel expressInfo)
        {
            ExpressInfoSql expressInfoSql = new ExpressInfoSql();
            return expressInfoSql.insertExpressInfo(expressInfo);
        }
    }
}
