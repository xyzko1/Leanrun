using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Entity
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：陈彬彬
    /// 日 期：2016.04.21 09:58
    /// 描 述：连接用户信息类(包括web端登录,或者接口形式的连接)
    /// </summary>
    public class UserInfoModel
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 连接时间
        /// </summary>
        public DateTime ConnectTime { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 对象用户关系Id,对象分类:1-部门2-角色3-岗位4-群组
        /// </summary>
        public string ObjectId { get; set; }
        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 登录IP地址所在地址
        /// </summary>
        public string IPAddressName { get; set; }
        /// <summary>
        /// 是否系统账户；拥有所以权限
        /// </summary>
        public bool IsSystem { get; set; }
        /// <summary>
        /// 登录Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string Secretkey { get; set; }
    }
    public class AdministrativeEntity
    {
        /// <summary>
        /// 行政区划名称
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

    }

    public class TBL_HAZARDBASICINFO
    {
        public string UNIFIEDCODE { get; set; }
        public string DISASTERNAME { get; set; }
        public string DISASTERTYPE { get; set; }
        public string LOCATION { get; set; }
        public string PROVINCE { get; set; }
        public string PROVINCENAME { get; set; }
        public string CITY { get; set; }
        public string CITYNAME { get; set; }
        public string COUNTY { get; set; }
        public string COUNTYNAME { get; set; }
        public string TOWN { get; set; }
        public string TOWNNAME { get; set; }
        public string MONITORRESPONSIBLE { get; set; }
        public string MONITORRESPONSIBLETEL { get; set; }
        public string GROUPMONITORINGSTAFF { get; set; }
        public string GROUPMONITORINGSTAFFTEL { get; set; }
        public string OBSERVATIONPEOPLE { get; set; }
        public DateTime? MODIFYTIME { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public string OCITY { get; set; }
        public string OCOUNTY { get; set; }
        public string OTOWN { get; set; }
    }
  
}
