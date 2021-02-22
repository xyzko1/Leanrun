using Infoearth.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Service
{
    public class DbTimeType
    {
        public static string DateTimeToDbTimeTypeEx(DateTime time)
        {
            DatabaseType dbType = DatabaseType.Oracle;
            string providerName = ConfigurationManager.ConnectionStrings["BaseDb"].ProviderName;
            string result = string.Empty;
            switch (providerName)
            {
                case "System.Data.SqlClient":
                    result = "'" + time.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    break;
                case "MySql.Data.MySqlClient":
                    result = "'" + time.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    break;
                case "Oracle.ManagedDataAccess.Client":
                    result = "TO_DATE('" + time.ToString("yyyy-MM-dd HH:mm:ss") + "', 'yyyy-MM-dd HH24:MI:ss')";
                    break;
                default:
                    throw new Exception("数据库类型目前不支持！");
                    break;
            }
            return result;
        }
    }
}

