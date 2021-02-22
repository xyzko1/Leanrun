using Infoearth.Data.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Infoearth.Application.Web
{
    /// <summary>
    /// 应用程序全局设置
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// 启动应用程序
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleTable.EnableOptimizations = false;
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            try
            {
                iTelluro.WebApi.Filter.HelpPageConfig.Register(GlobalConfiguration.Configuration, HttpContext.Current.Server.MapPath("~/App_Data/iTelluro.Busness.WebApi.xml"));
                bool isRegist = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["WebApiRegist"]);
                if (isRegist)
                {
                    string baseUrl = System.Configuration.ConfigurationManager.AppSettings["WebBusinessUrl"];
                    BusinessWebApiScan.WebApiRegistorForSSOWithXML(baseUrl);
                }

                //EF启用缓存
                bool isEFCache=bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsEFCache"]);
                if (isEFCache)
                {
                    string efConKeys = System.Configuration.ConfigurationManager.AppSettings["EFConKeys"];
                    if (!string.IsNullOrEmpty(efConKeys))
                    {
                        string[] conArr = efConKeys.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item in conArr)
                        {
                            string providerName = ConfigurationManager.ConnectionStrings[item].ProviderName;
                            switch (providerName)
                            {
                                case "System.Data.SqlClient":
                                    {
                                        using (var dbContext = new SqlServerDbContext(item))
                                        {
                                            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
                                            var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                                            mappingCollection.GenerateViews(new List<EdmSchemaError>());
                                        }
                                    }
                                    break;
                                case "MySql.Data.MySqlClient":
                                    {
                                        using (var dbContext = new MySqlDbContext(item))
                                        {
                                            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
                                            var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                                            mappingCollection.GenerateViews(new List<EdmSchemaError>());
                                        }
                                    }
                                    break;
                                case "Oracle.ManagedDataAccess.Client":
                                    {
                                        using (var dbContext = new OracleDbContext(item))
                                        {
                                            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
                                            var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                                            mappingCollection.GenerateViews(new List<EdmSchemaError>());
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// 应用程序错误处理
        /// </summary>
        protected void Application_Error(object sender, EventArgs e)
        {
            var lastError = Server.GetLastError();
        }

    }
}