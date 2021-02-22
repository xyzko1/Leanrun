using System.Web.Http;
using System.Web.Http.Cors;

namespace Infoearth.Application.Web
{
    /// <summary>
    /// api设置
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 注册配置
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
