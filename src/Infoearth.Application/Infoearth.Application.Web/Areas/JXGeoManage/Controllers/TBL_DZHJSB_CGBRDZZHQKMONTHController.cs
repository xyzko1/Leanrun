using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System;
using System.Data;
using System.IO;
using System.Web;
using System;
using System.Collections.Generic;
using Infoearth.Application.Busines;
using System.Linq;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-10 09:57
    /// �� ����TBL_DZHJSB_CGBRDZZHQKMONTH
    /// </summary>
    public class TBL_DZHJSB_CGBRDZZHQKMONTHController : MvcControllerBase
    {
        private TBL_DZHJSB_CGBRDZZHQKMONTHBLL tbl_dzhjsb_cgbrdzzhqkmonthbll = new TBL_DZHJSB_CGBRDZZHQKMONTHBLL();
        private TBL_DZHJSB_DZZHQKMONTHBLL tbl_dzhjsb_dzzhqkmonthbll = new TBL_DZHJSB_DZZHQKMONTHBLL();
        
        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DZHJSB_CGBRDZZHQKMONTHIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DZHJSB_CGBRDZZHQKMONTHForm()
        {
            return View();
        }
        #endregion

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        [LogContent("TBL_DZHJSB_CGBRDZZHQKMONTH", OpType.Query)]
        public ActionResult GetListJson(string queryJson)
        {
            var data = tbl_dzhjsb_cgbrdzzhqkmonthbll.GetList(queryJson);
            return ToJsonResult(data);
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = tbl_dzhjsb_cgbrdzzhqkmonthbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region ������ط���
        public static List<TBL_DZHJSB_CGBRDZZHQKMONTHEntity> testListCGBRDZZHQKMONTH = new List<TBL_DZHJSB_CGBRDZZHQKMONTHEntity>();
        public static List<TBL_DZHJSB_DZZHQKMONTHEntity> testListDZZHQKMONTH = new List<TBL_DZHJSB_DZZHQKMONTHEntity>();
        public ActionResult ImportExcelDataSave(string year, string month, string bbtype)
        {
            if (bbtype == "2")
            {
                if (testListCGBRDZZHQKMONTH.Count > 0 && testListCGBRDZZHQKMONTH != null && !string.IsNullOrEmpty(year))
                {
                    List<TBL_DZHJSB_CGBRDZZHQKMONTHEntity> testList = new List<TBL_DZHJSB_CGBRDZZHQKMONTHEntity>();
                    var oldlist = tbl_dzhjsb_cgbrdzzhqkmonthbll.GetList(null);
                    foreach (var item in testListCGBRDZZHQKMONTH)
                    {
                        short y = Convert.ToInt16(year);
                        short m = Convert.ToInt16(month);
                        var newlist = oldlist.Where(s => s.DISASTERYEAR == y && s.DISASTERMONTH == m && s.CITYNAME == item.CITYNAME).ToList();
                        if (newlist.Count > 0)
                        {
                            tbl_dzhjsb_cgbrdzzhqkmonthbll.RemoveForm(newlist.FirstOrDefault().GUID);
                        }
                        item.DISASTERYEAR = y;
                        item.DISASTERMONTH = m;
                        tbl_dzhjsb_cgbrdzzhqkmonthbll.SaveForm(null, item);
                    }
                }
                return Success("�����ɹ���");
            }
            else if (bbtype == "1")
            {
                if (testListDZZHQKMONTH.Count > 0 && testListDZZHQKMONTH != null && !string.IsNullOrEmpty(year))
                {
                    List<TBL_DZHJSB_DZZHQKMONTHEntity> testList = new List<TBL_DZHJSB_DZZHQKMONTHEntity>();
                    var oldlist = tbl_dzhjsb_dzzhqkmonthbll.GetList(null);
                    foreach (var item in testListDZZHQKMONTH)
                    {
                        short y = Convert.ToInt16(year);
                        short m = Convert.ToInt16(month);
                        var newlist = oldlist.Where(s => s.DISASTERTEAR == y && s.DISASTERMONTH == m && s.CITYNAME == item.CITYNAME).ToList();
                        if (newlist.Count > 0)
                        {
                            tbl_dzhjsb_dzzhqkmonthbll.RemoveForm(newlist.FirstOrDefault().GUID);
                        }
                        item.DISASTERTEAR = y;
                        item.DISASTERMONTH = m;
                        tbl_dzhjsb_dzzhqkmonthbll.SaveForm(null, item);
                    }
                }
                return Success("�����ɹ���");
            }
            return Error("û�л�ȡ��excel�е����ݡ�");
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult ImportExcelData(string year, string month, string bbtype)
        {
            try
            {
                System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                if (files.Count > 0)
                {
                    var file = files[0];
                    string dir = System.Web.HttpContext.Current.Server.MapPath("/Temp");
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + file.FileName);
                    file.SaveAs(filePath);
                    DataTable data = DataTableToEntity.GetData(filePath) as DataTable;
                    DataTable newdata = new DataTable();
                    if (data.Rows.Count <= 2)
                    {
                        return ToJsonResult("������");
                    }
                    var type = data.Rows[0][0].ToString().Split(':');
                    if (type[1] != "�±�")
                    {
                        return ToJsonResult("��ѡ����ȷ�ı������͡�");
                    }
                    if (bbtype != type[1])
                    {
                        System.IO.File.Delete(filePath);
                        return ToJsonResult(type[0] + "���Ͳ�һ�¡�");
                    }
                    //if (bbtype != data.Rows[0][0].ToString().Split(':')[1])
                    //{
                    //    System.IO.File.Delete(filePath);
                    //    return ToJsonResult("1");
                    //}
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(data.Rows[1][i].ToString()))
                        {
                            newdata.Columns.Add(data.Rows[1][i].ToString());
                        }
                    }
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (i > 3)
                        {
                            DataRow dr = newdata.NewRow();
                            dr = data.Rows[i];
                            if (newdata.Rows.Count > 0 && newdata.Rows.Count != i + 1)
                            {
                                dr[0] = newdata.Rows[0][0].ToString();
                            }
                            newdata.Rows.Add(dr.ItemArray);
                            //newdata.ImportRow(dr);
                        }
                    }
                    System.IO.File.Delete(filePath);
                    if (newdata != null)
                    {
                        if (bbtype == "2")
                        {
                            testListCGBRDZZHQKMONTH = newdata.ConvertToModel<TBL_DZHJSB_CGBRDZZHQKMONTHEntity>();
                            return ToJsonResult(testListCGBRDZZHQKMONTH);
                        }
                        else
                        {
                            testListDZZHQKMONTH = newdata.ConvertToModel<TBL_DZHJSB_DZZHQKMONTHEntity>();
                            return ToJsonResult(testListDZZHQKMONTH);
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("TBL_DZHJSB_CGBRDZZHQKMONTH", OpType.Delete)]
        public ActionResult RemoveForm(string keyValue)
        {
            tbl_dzhjsb_cgbrdzzhqkmonthbll.RemoveForm(keyValue);
            return Success("ɾ���ɹ���");
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        [LogContent("TBL_DZHJSB_CGBRDZZHQKMONTH", OpType.Update)]
        public ActionResult SaveForm(string keyValue, TBL_DZHJSB_CGBRDZZHQKMONTHEntity entity)
        {
            tbl_dzhjsb_cgbrdzzhqkmonthbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
