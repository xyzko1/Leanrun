using Infoearth.Application.Entity.DMCJManage;
using Infoearth.Application.Busines.DMCJManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using System.Web.Mvc;
using System.Collections.Generic;
using Infoearth.Util.Offices;
using Infoearth.Application.Web.Controllers;
using System.Linq;
using System;

namespace Infoearth.Application.Web.Areas.DMCJManage.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 12:10
    /// �� ����������������
    /// </summary>
    public class TBL_DMCJ_BASEINFOController : MvcControllerBase
    {
        private TBL_DMCJ_BASEINFOBLL tbl_dmcj_baseinfobll = new TBL_DMCJ_BASEINFOBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_BASEINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_BASEINFOForm()
        {
            return View();
        }
        #endregion



        /// <summary>
        /// ����������ͼ
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
            var data = tbl_dmcj_baseinfobll.GetMaxCode(xzqh);

            return data;
        }
        /// <summary>
        /// ����������ѯ������Excel��
        /// </summary>
        /// <param name="queryJson"></param>
        /// <param name="outColumn"></param>
        [HttpGet]
        public void ExcelDownload(string queryJson, string outColumn)
        {
            var list = tbl_dmcj_baseinfobll.GetList(queryJson).ToList();

            string[] columnArr = outColumn.TrimEnd(',').Split(',');//Ҫ��������

            List<ColumnEntity> ColumnList = new List<ColumnEntity>();
            IDictionary<string, string> dicArr = UtilityController.GetAllPropertyDic<TBL_DMCJ_BASEINFOEntity>();//��ȡ�ֵ��ֶ�
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
            excelConfig.FileName = "����������ѯ-" + DateTime.Now.ToString("yyyy.MM.dd") + ".xls";
            excelConfig.Title = "����������ѯ";
            ExcelHelperEx<TBL_DMCJ_BASEINFOEntity>.ExcelDownload(list, excelConfig, true);


        }
    }
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 12:10
    /// �� �����������������ѯҳ��
    /// </summary>
    public class TBL_DMCJ_BASESELECTController : MvcControllerBase
    {
        private TBL_DMCJ_BASEINFOBLL tbl_dmcj_baseinfobll = new TBL_DMCJ_BASEINFOBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Login]
        public ActionResult TBL_DMCJ_BASEINFOIndex()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TBL_DMCJ_BASEINFOForm()
        {
            return View();
        }
        #endregion

       
    }
}
