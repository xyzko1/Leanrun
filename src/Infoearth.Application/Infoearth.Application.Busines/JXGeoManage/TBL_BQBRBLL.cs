using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;
using Infoearth.Util;
using Infoearth.Application.Common;
using Infoearth.Util.Extension;
using Infoearth.Application.Entity;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:25
    /// �� ������Ǩ������Ϣ��
    /// </summary>
    public class TBL_BQBRBLL
    {
        private TBL_BQBRIService service = new TBL_BQBRService();

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_BQBREntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        public IEnumerable<TBL_BQBREntity> GetZYPageList(string queryJson, string condition)
        {
            return service.GetZYPageList(queryJson, condition);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<tbl_bqbrnew> GetPageLists(Pagination pagination, string queryJson, string condition)
        {

            //var list = service.GetPageList(pagination, queryJson);
            var list = service.GetPageListNEW(pagination, queryJson);
            List<tbl_bqbrnew> result = new List<tbl_bqbrnew>();
            var queryParam = condition.ToJObject();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (!item.LONGITUDE.HasValue || !item.LATITUDE.HasValue)
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                pagination.records = result.Count;
                return result;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (!item.LONGITUDE.HasValue || !item.LATITUDE.HasValue)
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                    if (isInsert)
                    {
                        result.Add(item);
                    }

                }
                pagination.records = result.Count;
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
                pagination.records = result.Count;
                return result;
            }
            return list;
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_BQBREntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_BQBREntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        public TBL_BQBREntity GetEntityByUnifycode(string keyValue)
        {
            return service.GetEntityByUnifycode(keyValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <param name="CityName"></param>
        /// <param name="CountyName"></param>
        /// <param name="BQBRYEAR"></param>
        /// <param name="BQBRUNIT"></param>
        /// <param name="EXLType"></param>
        /// <returns></returns>
        public DataTable BQBRCountStatics(string ProvinceName, string CityName, string CountyName, string BQBRYEAR, string BQBRUNIT, string EXLType)
        {
            return service.BQBRCountStatics(ProvinceName, CityName, CountyName, BQBRYEAR, BQBRUNIT, EXLType);
        }
        public EchartEntityNEWS GetListCodes()
        {
            return service.GetListCodes();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetDataTableList(string queryJson)
        {
            return service.GetDataTableList(queryJson);
        }
        public IEnumerable<TBL_BQBREntity> GetZYList(string queryJson, string condition)
        {
            return service.GetZYList(queryJson, condition);
        }

        /// <summary>
        /// ��Ǩ����ͳ�Ʋ�ѯ
        /// </summary>
        /// <param name="codeValue">�����������</param>
        /// <param name="codeType">������������</param>
        /// <param name="xmmc">��Ŀ����</param>
        /// <param name="annual">��������</param>
        /// <param name="static_Unit">ͳ�Ƶ�λ</param>
        /// <returns></returns>
        public DataTable GetDataBqbrTj(string codeValue, string codeType, string xmmc, string annual, string static_Unit)
        {
            return service.GetDataBqbrTj(codeValue, codeType, xmmc, annual, static_Unit);
        }
        #endregion

        public IEnumerable<TreeByBQBRTJ> GetTJ(string queryJson)
        {
            return service.GetTJ(queryJson);
        }
        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
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
        public string SaveForm(string keyValue, TBL_BQBREntity entity)
        {
            try
            {
                string SuccessGuid = service.SaveForm(keyValue, entity);
                return SuccessGuid;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
