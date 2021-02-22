using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Application.Common;
using Infoearth.Application.Entity;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:27
    /// �� ������������Ϣ��
    /// </summary>
    public class TBL_ZLGC_BASEINFOBLL
    {
        private TBL_ZLGC_BASEINFOIService service = new TBL_ZLGC_BASEINFOService();

        public EchartEntityNEWS GetListCodes()
        {
            return service.GetListCodes();
        }

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetPageLists(Pagination pagination, string queryJson, string condition)
        {
            var list = service.GetPageList(pagination, queryJson);
            List<TBL_ZLGC_BASEINFOEntity> result = new List<TBL_ZLGC_BASEINFOEntity>();
            var queryParam = condition.ToJObject();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                return result;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                return result;
            }
            if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                string polyline = queryParam["polyline"].ToString();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                return result;
            }
            //  //����׶�

            //Ұ�⿱��
            //
            return list;
        }
       
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetList(string queryJson)
        {
            return service.GetListS(queryJson);
        }
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZYPageList(string queryJson, string condition)
        {
            return service.GetZYPageList(queryJson, condition);
        }
        public object PdState1(string id)
        {
            return service.PdState1(id);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_ZLGC_BASEINFOEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public DataTable ZLGCCountStatics(string ProvinceName,string CityName,string CountyName,string ZLGCYEAR,string ZLGCUNIT, string DC)
        {
            return service.ZLGCCountStatics(ProvinceName, CityName, CountyName, ZLGCYEAR, ZLGCUNIT, DC);
        }
        public DataTable ZLGCCountStaticsNew(string xzqhcode, string ProvinceName, string CityName, string CountyName, string ZLGCYEAR, string ZLGCUNIT)
        {
            return service.ZLGCCountStaticsNew(xzqhcode,ProvinceName, CityName, CountyName, ZLGCYEAR, ZLGCUNIT);
        }
        /// <summary>
        /// ����������ͳ�Ʒ���
        /// </summary>
        /// <param name="codeValue">������������</param>
        /// <param name="codeType">ʡ����</param>
        /// <param name="ZLGCYEAR">���</param>
        /// <param name="ZLGCUNIT">ͳ�Ƶ�λ</param>
        /// <returns></returns>
        public DataTable GetDataZLGCStatics(string codeValue, string codeType, string ZLGCYEAR, string ZLGCUNIT)
        {
            return service.GetDataZLGCStatics(codeValue, codeType, ZLGCYEAR, ZLGCUNIT);
        }
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZLGTJResult(string queryJson)
        {
            return service.GetZLGTJResult(queryJson);
        }
        /// <summary>
        /// ����ҳ��ѯ�������б���Ϣ
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetListS(string queryJson)
        {
            return service.GetListS(queryJson); 
        }
        public IEnumerable<TBL_ZLGC_BASEINFOEntity> GetZYList(string queryJson, string condition)
        {
            return service.GetZYList(queryJson, condition);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public string RemoveForm(string keyValue)
        {
            try
            {
                string result=service.RemoveForm(keyValue);
                return result;
            
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public PASTBL_ZLGC_BASEINFOEntity SaveForm(string keyValue, TBL_ZLGC_BASEINFOEntity entity)
        {
            try
            {
                PASTBL_ZLGC_BASEINFOEntity da = new PASTBL_ZLGC_BASEINFOEntity();
                da = service.SaveForm(keyValue, entity);
                return da;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SaveForm_New(string keyValue, TBL_ZLGC_BASEINFOEntity entity)
        {
            try
            {
                string result=service.SaveForm_New(keyValue, entity);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
 
        }

        #endregion
    }
}
