using Infoearth.Application.Entity.MONITORPOINT;
using Infoearth.Application.Busines.MONITORPOINT;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using Infoearth.Util.Offices;
using System.Linq;
using Infoearth.Application.Web.Controllers;

namespace Infoearth.Application.Web.Areas.MONITORPOINT.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 18:23
    /// �� �����������������Ϣ��
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTController : MvcControllerBase
    {
        private TBL_DMCJ_MONITORPOINTBLL tbl_dmcj_monitorpointbll = new TBL_DMCJ_MONITORPOINTBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_MONITORPOINTIndex()
        {
            return View();
        }
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_MONITORIndex()
        {
            return View();
        }
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_Select()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_MONITORPOINTForm()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_MONITORForm()
        {
            return View();
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateCodeWaterIndex()
        {
            return View();
        }
        /// <summary>
        /// �������λ�������
        /// </summary>
        /// <param name="xzqh"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetMaxCode(string xzqh)
        {
            var data = tbl_dmcj_monitorpointbll.GetMaxCode(xzqh);

            return data;
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_MONITORPOINTJCSJForm()
        {
            return View();
        }
        #endregion



        /// <summary>
        /// �����ѯ(����Excel)
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="outColumn"></param>
        [HttpGet]
        public void ExcelDownload(string queryJson, string outColumn)
        {
            var list = tbl_dmcj_monitorpointbll.GetList(queryJson).ToList();

            string[] columnArr = outColumn.TrimEnd(',').Split(',');//Ҫ��������

            List<ColumnEntity> ColumnList = new List<ColumnEntity>();
            IDictionary<string, string> dicArr = UtilityController.GetAllPropertyDic<TBL_DMCJ_MONITORPOINTEntity>();//��ȡ�ֵ��ֶ�
            //��ʾ��
            foreach (var item in dicArr.Keys)
            {
                if (columnArr.Contains(item))
                {
                    ColumnList.Add(new ColumnEntity { Column = item, ExcelColumn = dicArr[item], Width = 30 });
                }
            }
            UtilityController.ConvertDicValue(list);//�ֵ��ֵ
            ExcelConfig excelConfig = new ExcelConfig();
            excelConfig.IsAllSizeColumn = true;
            excelConfig.ColumnEntity = ColumnList;
            excelConfig.FileName = "�����ѯ-" + DateTime.Now.ToString("yyyy.MM.dd") + ".xls";
            excelConfig.Title = "�����ѯ";
            ExcelHelperEx<TBL_DMCJ_MONITORPOINTEntity>.ExcelDownload(list, excelConfig, true);


        }


    }
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 18:23
    /// �� �����������������Ϣ��ѯ
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTSELECTController : MvcControllerBase
    {
        private TBL_DMCJ_MONITORPOINTBLL tbl_dmcj_monitorpointbll = new TBL_DMCJ_MONITORPOINTBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_MONITORPOINTIndex()
        {
            return View();
        }
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_MONITORIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_MONITORPOINTForm()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_MONITORForm()
        {
            return View();
        }
        #endregion


    }

   
}
