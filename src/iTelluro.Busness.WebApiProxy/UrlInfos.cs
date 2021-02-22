using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTelluro.Busness.WebApiProxy
{
    /// <summary>
    /// 访问地址信息
    /// </summary>
    public class UrlInfos
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 业务系统Code
        /// </summary>
        public string BusinessCode { get; set; }

        /// <summary>
        /// 菜单是否从SSO获取
        /// </summary>
        public bool IsMeunFromSSO { get; set; }
    }
}
