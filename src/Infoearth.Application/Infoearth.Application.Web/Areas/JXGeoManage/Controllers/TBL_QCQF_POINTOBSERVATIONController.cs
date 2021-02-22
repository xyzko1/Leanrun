using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-06-11 15:39
    /// 描 述：群测群防监测点和观测人关联表
    /// </summary>
    public class TBL_QCQF_POINTOBSERVATIONController : MvcControllerBase
    {
        private TBL_QCQF_POINTOBSERVATIONBLL tbl_qcqf_pointobservationbll = new TBL_QCQF_POINTOBSERVATIONBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_QCQF_POINTOBSERVATIONIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_QCQF_POINTOBSERVATIONForm()
        {
            return View();
        }
        #endregion
        [HttpPost]
        public ActionResult SaveFormByID(string ID,string UNIFIEDCODE)
        {
            tbl_qcqf_pointobservationbll.SaveFormByID(ID, UNIFIEDCODE);
            return Success("操作成功。");
        }
        [HttpGet]
        public ActionResult GetDataJcd(string id)
        {
            var data = tbl_qcqf_pointobservationbll.GetDataJcd(id);
            data.Columns[0].ColumnName = "GUID";
            data.Columns[1].ColumnName = "MONITORPOINTCODE";
            data.Columns[2].ColumnName = "MONITORPOINTPOSITION";
            data.Columns[3].ColumnName = "UNIFIEDCODE";
            data.Columns[4].ColumnName = "DISASTERNAME";
            data.Columns[5].ColumnName = "LOCATION";
            return ToJsonResult(data);
        }
        [HttpGet]
        public ActionResult GetDataJcr(string id)
        {
            var data = tbl_qcqf_pointobservationbll.GetDataJcr(id);
            data.Columns[0].ColumnName = "OBSERVATIONPEOPLE";
            data.Columns[1].ColumnName = "OBSERVATIONPHONE";
            data.Columns[2].ColumnName = "GUID";
            return ToJsonResult(data);
        }
        [HttpGet]
        public ActionResult  delegl(string id, string guid)
        {
            tbl_qcqf_pointobservationbll.delegl(id,guid);
            return Success("删除成功。");
        }
        [HttpGet]
        public ActionResult deleglnew(string id)
        {
            tbl_qcqf_pointobservationbll.deleglnew(id);
            return Success("删除成功。");
        }
        [HttpGet]
        public ActionResult deleglnewByqCqf(string id)
        {
            tbl_qcqf_pointobservationbll.deleglnewByqCqf(id);
            return Success("删除成功。");
        }
    }
}
