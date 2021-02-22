using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 业务系统公共Api接口
    /// </summary>
    public class UniversalApiController : ApiControllerBase
    {
        /// <summary>
        /// 获取api接口数量
        /// </summary>
        /// <returns></returns>
        public int GetApiCount()
        {
            int count = 0;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type t in types)
            {
                var s = t.BaseType.ToString().Contains("ApiControllerBase");
                if (s)
                {
                    IEnumerable<MethodInfo> ls = t.GetTypeInfo().DeclaredMethods;
                    foreach (var v in ls)
                    {
                        if (v.IsPublic)
                            count++;
                    }
                }
            }
            return count;
        }
    }
}
