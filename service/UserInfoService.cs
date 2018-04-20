using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServer;
using Model;

namespace service
{
    public class UserInfoService
    {
        public List<UserInfoModel> getAllUserInfo() {
            UserInfoSql userinfosql = new UserInfoSql();
            return userinfosql.getAllUserInfoData();
        }
    }
}
